using GoalTracker.MvcUI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tracker.BackService.Models;

namespace GoalTracker.MvcUI.Services
{
  public interface IApiClient
  {
    Task<List<WalkGoal>> GetWalkGoalsAsync();
    Task<WalkGoal> GetWalkGoalAsync(int id);
    Task PutWalkGoalAsync(WalkGoal goalToUpdate);
    Task AddWalkGoalAsync(WalkGoal goalToAdd);
    Task RemoveWalkGoalAsync(int id);
  }

  public class ApiClient : IApiClient
  {
    private readonly HttpClient _HttpClient;
    public ApiClient(HttpClient httpClient)
    {
      _HttpClient = httpClient;
    }

    public async Task AddWalkGoalAsync(WalkGoal goalToAdd)
    {
      var response = await _HttpClient.PostJsonAsync("api/WalkGoals", goalToAdd);
      response.EnsureSuccessStatusCode();
    }

    public async Task<WalkGoal> GetWalkGoalAsync(int id)
    {
      var response = await _HttpClient.GetAsync($"/api/WalkGoals/{id}");
      response.EnsureSuccessStatusCode();

      return await response.Content.ReadAsJsonAsync<WalkGoal>();
    }

    public async Task<List<WalkGoal>> GetWalkGoalsAsync()
    {
      var response = await _HttpClient.GetAsync("/api/WalkGoals");
      response.EnsureSuccessStatusCode();

      return await response.Content.ReadAsJsonAsync<List<WalkGoal>>();
    }

    public async Task PutWalkGoalAsync(WalkGoal goalToUpdate)
    {
      var response = await _HttpClient.PutJsonAsync("api/WalkGoals", goalToUpdate);
      response.EnsureSuccessStatusCode();
    }

    public async Task RemoveWalkGoalAsync(int id)
    {
      var response = await _HttpClient.DeleteAsync($"api/WalkGoals/{id}");
      response.EnsureSuccessStatusCode();
    }
  }
}
