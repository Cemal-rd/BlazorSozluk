﻿using BlazorSozluk.Common.ViewModels;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient client;
        public VoteService(HttpClient client)
        {
            this.client = client;
        }
        public async Task DeleteEntryVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote ERROR");
        }
        public async Task DeleteEntryCommentVote(Guid entryCommentId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryCommentVote ERROR");
        }
        public async Task CreateEntryUpVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.UpVote);
        }
        public async Task CreateEntryDownVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.DownVote);

        }
        public async Task CreateEntryCommentUpVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.UpVote);
        }
        public async Task CreateEntryCommentDownVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);

        }
        private async Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entry/{entryId}?voteType={voteType}", null);
            if (result.IsSuccessStatusCode)
            {
                // Başarılı durum
                Console.WriteLine("Vote successfully created.");
            }
            else
            {
                // Başarısız durum
                Console.WriteLine("Failed to create vote.");
            }

            return result;
        }
        private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entrycomment/{entryCommentId}?voteType={voteType}", null);
            if (result.IsSuccessStatusCode)
            {
                // Başarılı durum
                Console.WriteLine("Vote successfully created.");
            }
            else
            {
                // Başarısız durum
                Console.WriteLine("Failed to create vote.");
            }

            return result;
        }


    }
}
