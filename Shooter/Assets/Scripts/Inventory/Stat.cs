using System;

[Serializable]
public struct Stat
{
    public string _name;

    public float _value;

    public float Value {get => _value; set => _value = value;}
    public string Name {get => _name; set => _name = value;}

    public Stat(string name, float value)
    {   
        _name = name;
        _value = value;
    }

    public override string ToString()
    {
        return $"{_name} : {_value}";
    }
}
