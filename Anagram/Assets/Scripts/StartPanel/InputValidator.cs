using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputValidator : MonoBehaviour {

    public void Start()
    {
        GetComponent<InputField>().onValidateInput += (input, charIndex, addedChar) => MyValidate(addedChar);
    }

    private char MyValidate(char charToValidate)
    {
        int code = (int) charToValidate;
        // for lower and upper cases respectively
        if ((code > 96 && code < 123) || (code > 64 && code < 91) || charToValidate == ' ')
            return charToValidate;
        return new char();
    }
}
