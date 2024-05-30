using Practica_APIs.MVVM.Models;
using Practica_APIs.MVVM.ViewModels;
using PropertyChanged;

namespace Practica_APIs.MVVM.Views;

[AddINotifyPropertyChangedInterface]
public partial class VDashboard : ContentPage
{
    public VDashboard()
    {
        InitializeComponent();
        BindingContext = new VMDasboard();
    }
    
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is PokemonInfo selectedPokemon)
        {
            ((VMDasboard)BindingContext).SelectedPokemon = selectedPokemon;
            
            ((VMDasboard)BindingContext).ShowPokemonDetailsCommand.Execute(null);
        }
    }
}