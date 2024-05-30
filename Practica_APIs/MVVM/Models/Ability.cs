using Newtonsoft.Json;

namespace Practica_APIs.MVVM.Models;

public class Ability
{
    public Ability2 ability { get; set; }
    public bool is_hidden { get; set; }
    public int slot { get; set; }
}