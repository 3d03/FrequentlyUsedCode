

public enum body_type_enum { universal, sedan, suv}
[System.Serializable]
public class Car 
{
    public string brand;
    public string model;
    public body_type_enum body_type;
}
