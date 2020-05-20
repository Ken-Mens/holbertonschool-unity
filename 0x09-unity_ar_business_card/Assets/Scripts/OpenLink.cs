using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{

    public void Github_Link()
    {
        Application.OpenURL("https://github.com/Ken-Mens");
    }

    public void IN_Link()
    {
        Application.OpenURL("https://www.linkedin.com/in/kenneth-mensah-07612238/");
    }

    public void TWitter_Link()
    {
        Application.OpenURL("https://twitter.com/Kmens5");
    }

    public void Email_Link()
    {
        Application.OpenURL("mailto:525@holbertonschool.com");
    }
}

