using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    GUIStyle style;
    char[] characters;
    string tobecat;
    string count;
    
    int firstcharacter;
    int secondcharacter;
    int thirdcharacter;

    int counts;
   
    float timer;
    int timertoshow;
    public Text text;
    public Text cat;
    public Text alltext;

    // Use this for initialization
	void Start ()
    {
        style = new GUIStyle();
        style.fontSize = 50;

        counts = 0;

        characters = new char[27];
	for (int i = 0; i < 26; i++)
        {
            characters[i] = (char)(97 + i);
        }
        characters[26]=(char)20;
        
        /*do
        {
            
            firstcharacter = Random.Range(0, characters.Length -1);
            secondcharacter = Random.Range(0, characters.Length - 1);
            thirdcharacter = Random.Range(0, characters.Length - 1);
            tobecat = string.Format("{0}{1}{2}", characters[firstcharacter], characters[secondcharacter], characters[thirdcharacter]);
            Debug.Log(tobecat);
            counts += 1;
            
            timer += Time.deltaTime;

        } while (firstcharacter != 2||secondcharacter!=0||thirdcharacter!=19);
        timertoshow = Mathf.CeilToInt(timer);

        count = string.Format(" 'cat'\nCounting Times:{0}\nTime:{1}",counts,timertoshow);*/

    }
    

    /*private void OnGUI()
    {
         GUI.Label(new Rect(40, 40, 200, 50), count,style);
        
        
       if (GUI.skin.customStyles.Length > 0)
            GUI.skin.customStyles[0].wordWrap = true;
       
    }*/
    // Update is called once per frame
    void Update () 
    {
	    if(firstcharacter != 2 || secondcharacter != 0 || thirdcharacter != 19)
        {
            firstcharacter = Random.Range(0, characters.Length - 1);
            secondcharacter = Random.Range(0, characters.Length - 1);
            thirdcharacter = Random.Range(0, characters.Length - 1);
            tobecat = string.Format("{0}{1}{2}", characters[firstcharacter], characters[secondcharacter], characters[thirdcharacter]);
            Debug.Log(tobecat);
            counts += 1;
            cat.text = tobecat;
            alltext.text = tobecat + "\n"+alltext.text;
            timer += Time.deltaTime;
        }

        timertoshow = Mathf.CeilToInt(timer);

        count = string.Format(" Counting Times:{0}\nTime:{1}", counts, timertoshow);
        text.text = count;


        
	}
}
