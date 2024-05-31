using System.Diagnostics;
using Practica_APIs.MVVM.Models;
using Newtonsoft.Json;

namespace Practica_APIs.Services;

public class PokeAPIService
{
    public HttpClient _Client { get; set; }
    
    public PokeAPIService()
    {
        _Client = new HttpClient();
    }
    
    public async Task<List<PokemonInfo>> GetPokemons()
    {
        var response = await _Client.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=500");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var pokemonList = JsonConvert.DeserializeObject<PokemonList>(content);

        var pokemons = new List<PokemonInfo>();
        foreach (var p in pokemonList.Results)
        {
            var pokemonResponse = await _Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{p.Name}");
            pokemonResponse.EnsureSuccessStatusCode();

            var pokemonContent = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemonDetails = JsonConvert.DeserializeObject<PokemonInfo>(pokemonContent);

            pokemons.Add(new PokemonInfo() 
            { 
                Name = p.Name, 
                ImgUrl = GetImageUrlFromUrl(p.Url),
                abilities = pokemonDetails.abilities,
                types = pokemonDetails.types
            });
        }

        return pokemons;
    }

    private string GetImageUrlFromUrl(string url)
    {
        var segments = url.TrimEnd('/').Split('/');
        var id = segments.Last();
        return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{id}.png";
    }
    
    
}