using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorSozluk.Api.Application.Features.Queries.SearchBySubject;

public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
{
    private readonly IEntryRepository entryRepository;

    public SearchEntryQueryHandler(IEntryRepository entryRepository)
    {
        this.entryRepository = entryRepository;
    }

    public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.SearchText) || request.SearchText.Length < 3 || request.SearchText.Length > 25)
        {
            throw new ArgumentException("SearchText en az 3, en fazla 25 karakter uzunluğunda olmalıdır.");
        }

        var result = entryRepository
            .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
            .Select(i => new SearchEntryViewModel()
            {
                Id = i.Id,
                Subject = i.Subject,
            });

        return await result.ToListAsync(cancellationToken);
    }
}