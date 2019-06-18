using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IndrocutionSwitcher : MonoBehaviour
{
    public void onClickNext()
    {
        SceneManager.LoadScene(2);
    }
}
