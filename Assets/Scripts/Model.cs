using System.Data;
using UnityEngine;

public class Model : MonoBehaviour
{
    public string result;

    public void Calculate(string input)
    {
        DataTable dataTable = new DataTable();
        double  value = (double)dataTable.Compute(input, null);

        result = value.ToString();
    }
}