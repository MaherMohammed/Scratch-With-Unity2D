using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logic : MonoBehaviour
{
    public GameObject GF;

    static string path;
    static StreamReader reader;
    // Start is called before the first frame update
    void Start()
    {
        path = "Assets/PseudoCode/pseudocode.txt";
        // reader = new StreamReader(path);
        // print(GF.transform.position);
        // transform.up = new Vector3(1.0f, 0.0f, 0.0f);
    }

    void MoveFunction(string text)
    {
        //extract the number of steps
        int numOfSteps = extractNumberOfSteps(text);
        // print(numOfSteps);
        //execute movement
        transform.position += new Vector3(numOfSteps, 0.0f, 0.0f);
        // transform.position += new Vector3(transform.up.z, 0, -transform.up.x);
        // print(transform.forward);
    }

    void TurnRightFunction(string text)
    {
        //extract number of degrees
        int degrees = extractNumberOfDegrees(text);
        //execute the rotation
        transform.eulerAngles += Vector3.forward * -degrees;
        // print(transform.up);
    }

    int extractNumberOfSteps(string text)
    {
        int steps = 0;
        string num = "";
        for (int i = text.Length - 7; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out steps);
        return steps;
    }

    int extractNumberOfDegrees(string text)
    {
        int degrees = 0;
        string num = "";
        for (int i = text.Length - 9; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out degrees);
        return degrees;

    }

    void GoToFunction(string text)
    {
        //fetch x and y
        int x = fetchX(text);
        int y = fetchY(text);
        //execute the transformation
        transform.position = new Vector3(x, y, 0.0f);
    }

    int fetchX(string text)
    {
        int x = 0;
        string num = "";
        for (int i = 0; i < text.Length; i++)
        {
            // print(i);
            if (text[i].Equals('x'))
            {
                i++;
                i++;
                while (!text[i].Equals('_'))
                {
                    num += text[i];
                    i++;
                }
                break;

            }

        }
        int.TryParse(num, out x);
        // print(x);
        return x;
    }
    int fetchY(string text)
    {
        int y = 0;
        string num = "";
        for (int i = text.Length - 1; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out y);
        return y;
    }

    void ChangeXFunction(string text)
    {
        int x = getXToBeChanged(text);
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }

    void ChangeYFunction(string text)
    {
        int y = getYToBeChanged(text);
        transform.position += new Vector3(0.0f, y, 0.0f);
    }

    int getXToBeChanged(string text)
    {
        int x = 0;
        string num = "";
        for (int i = text.Length - 1; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out x);
        return x;
    }

    int getYToBeChanged(string text)
    {
        int y = 0;
        string num = "";
        for (int i = text.Length - 1; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out y);
        return y;
    }

    void SetXFunction(string text)
    {
        //extract x
        int x = getXToBeSet(text);
        //set x by the number extracted
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    void SetYFunction(string text)
    {
        //extract x
        int y = getYToBeSet(text);
        //set x by the number extracted
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    int getXToBeSet(string text)
    {
        int x = 0;
        string num = "";
        for (int i = text.Length - 1; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out x);
        return x;
    }


    int getYToBeSet(string text)
    {
        int y = 0;
        string num = "";
        for (int i = text.Length - 1; !text[i].Equals('_'); i--)
        {
            num = text[i] + num;
        }
        int.TryParse(num, out y);
        return y;
    }

    // int numberOfLoops = 0;
    void SpaceClicked()
    {
        reader = new StreamReader(path);
        string text = reader.ReadLine();
        // print(text);
        while (text != null)
        {
            if (compareStrings(text, "when_space_isClicked"))
            {
                text = reader.ReadLine(); // begin
                text = reader.ReadLine(); // after begin may be end
                while (!compareStrings(text, "  END"))
                {
                    if (text.Contains("move") && text.Contains("steps"))
                    {
                        //execute move function
                        // MoveFunction(text);
                    }
                    else if (text.Contains("turnR"))
                    {
                        //execute turn function
                        // TurnRightFunction(text);

                    }
                    else if (text.Contains("go_to"))
                    {
                        // GoToFunction(text);

                    }
                    else if (text.Contains("change_x"))
                    {
                        // ChangeXFunction(text);
                    }
                    else if (text.Contains("change_y"))
                    {
                        // ChangeYFunction(text);
                    }
                    else if (text.Contains("set_x"))
                    {
                        // SetXFunction(text);
                    }
                    else if (text.Contains("set_y"))
                    {
                        SetYFunction(text);
                    }


                    text = reader.ReadLine();
                    if (text == null)
                    {
                        break;
                    }
                }

            }

            text = reader.ReadLine();
        }
    }


    bool compareStrings(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < str1.Length; i++)
            {
                if (!str1[i].Equals(str2[i]))
                {
                    return false;
                }
            }

            return true;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("space"))
        {
            //execute the body
            SpaceClicked();

        }
        // if (Input.GetMouseButtonDown (0))
        // {
        //     if(Input.mousePosition.x >= GF.transform.position.x-0.25 && Input.mousePosition.x <= GF.transform.position.x+0.25){
        //         // if(Input.mousePosition.y >= 441 && Input.mousePosition.y <= 478){
        //            print(Input.mousePosition);

        //         // }
        //     }

    }
}

