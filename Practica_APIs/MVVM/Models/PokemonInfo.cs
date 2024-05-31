using Newtonsoft.Json;
using PropertyChanged;

namespace Practica_APIs.MVVM.Models;

[AddINotifyPropertyChangedInterface]
public class PokemonInfo
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
    
    public List<Ability> abilities { get; set; }
    
    public List<Type> types { get; set; }
    public string ImgUrl { get; set; }
    public int Index { get; set; }


}