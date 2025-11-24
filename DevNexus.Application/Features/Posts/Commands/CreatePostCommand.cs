using DevNexus.Domain.Entities;
using DevNexus.Domain.Enums;
using DevNexus.Application.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using DevNexus.Application.Storage;

namespace DevNexus.Application.Features.Posts.Commands;

public record TranslationDto(string Title, string Content, Lang Lang);

public record CreatePostCommand(IFormFile ImageFile, int CategoryId, List<TranslationDto> Translations) : IRequest<int>;

public class CreatePostCommandHandler(
    AppDbContext _context,
    IFormFileStorage _fileStorage
) : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var imagePath = await _fileStorage.UploadAsync("post-images", request.ImageFile);

        var post = new Post
        {
            ImageUrl = imagePath,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            Translations = request.Translations.Select(t => new PostTranslation
            {
                Title = t.Title,
                Content = t.Content,
                Lang = t.Lang,
                ShortDescription = (t.Content.Length <= 100) ? t.Content : t.Content.Substring(0, 100) + "..."
            }).ToList()
        };

        await _context.Posts.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}

public class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.ImageFile).NotNull();
        RuleFor(x => x.Translations).NotEmpty();
        RuleForEach(x => x.Translations).ChildRules(t =>
        {
            t.RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            t.RuleFor(x => x.Content).NotEmpty();
        });
    }
}