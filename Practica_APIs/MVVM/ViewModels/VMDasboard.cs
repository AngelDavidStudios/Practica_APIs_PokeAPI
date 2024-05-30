using System.Collections.ObjectModel;
using System.Windows.Input;
using Practica_APIs.MVVM.Views;
using Practica_APIs.MVVM.Models;
using Practica_APIs.Services;
using PropertyChanged;

namespace Practica_APIs.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class VMDasboard
{
    public ObservableCollection<PokemonInfo> Pokemons { get; set; }
    public PokemonInfo SelectedPokemon { get; set; }
    public ICommand ShowPokemonDetailsCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private PokeAPIService _pokeAPIService;

    public VMDasboard()
    {
        Pokemons = new ObservableCollection<PokemonInfo>();
        _pokeAPIService = new PokeAPIService();
        LoadPokemons();
        ShowPokemonDetailsCommand = new Command(ExecuteShowPokemonDetailsCommand);
        CloseCommand = new Command(ExecuteCloseCommand);

    }

    private async void LoadPokemons()
    {
        var pokemons = await _pokeAPIService.GetPokemons();
        for (int i = 0; i < pokemons.Count; i++)
        {
            pokemons[i].Index = i + 1;
            Pokemons.Add(pokemons[i]);
        }
    }

    private async void ExecuteShowPokemonDetailsCommand()
    {
        if (SelectedPokemon != null)
        {
            var pokemonDetailsPage = new PokemonDetailsPage { BindingContext = this };
            await Application.Current.MainPage.Navigation.PushModalAsync(pokemonDetailsPage);
        }
    }
    
    private async void ExecuteCloseCommand()
    {
        await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}