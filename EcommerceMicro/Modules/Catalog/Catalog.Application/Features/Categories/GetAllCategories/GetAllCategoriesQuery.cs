using Catalog.Domain.Entities;
using MediatR;

public record GetAllCategoriesQuery() : IRequest<List<Category>>;