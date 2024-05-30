namespace Practica_APIs.MVVM.Models;

public class ResourceList
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PokemonInfo> results { get; set; }
}