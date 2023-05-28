using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public int ConstantValue;
    public FloatVariable Variable;

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set { Variable.Value = value; }
    }
}