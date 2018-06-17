using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSkills : MonoBehaviour {
    public enum Pages {
        Cover,
        Page1,
        Page2,
        Back
    }

    public GameObject controllerVisual;
    public float pageSpacing;
    public float magazineOpenAngle;

    private bool isSelected;

    private Transform parent;
    private Vector3 oldPosition;
    private Quaternion oldRotation;

    private float startPosition;
    private float endPosition;

    private int selectedPage;
    private Transform currentPage;

    private bool isFliping;
    // Use this for initialization
    void Start () {
        parent = this.gameObject.transform.parent;
        oldPosition = this.gameObject.transform.position;
        oldRotation = this.gameObject.transform.rotation;
        selectedPage = (int) Pages.Cover;
        currentPage = gameObject.transform.GetChild(selectedPage).transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isSelected)
        //{
            if (GvrControllerInput.TouchDown)
            {
                startPosition = GvrControllerInput.TouchPosCentered.x;
            }
            if (GvrControllerInput.TouchUp)
            {
                if (GvrControllerInput.TouchPosCentered.x < startPosition)
                {
                    if (selectedPage < (int)Pages.Back)
                    {
                    currentPage.eulerAngles = new Vector3(currentPage.eulerAngles.x, currentPage.eulerAngles.y, (magazineOpenAngle - selectedPage));

                    //currentPage.Rotate (new Vector3(0, 0, (magazineOpenAngle - selectedPage)));
                    //currentPage.localEulerAngles = new Vector3(currentPage.eulerAngles.x, currentPage.eulerAngles.y, (magazineOpenAngle - selectedPage));


                    selectedPage++;
                    currentPage = gameObject.transform.GetChild(selectedPage).transform;
                    //StartCoroutine(TurnLeft(0.75f));
                    Debug.Log("Pagina: " + gameObject.transform.GetChild(selectedPage).name);
                        //magazineOpenAngle -= 1;
                    }
                    Debug.Log("Swipe Left");

                }
                else if (GvrControllerInput.TouchPosCentered.x > startPosition)
                {
                    Debug.Log("Swipe Right");
                    if (selectedPage > (int)Pages.Cover)
                    {
                    //currentPage.Rotate(new Vector3(0, 0, -(pageSpacing - selectedPage)/*currentPage.rotation.z - (magazineOpenAngle - selectedPage)*/));
                    //currentPage.rotation.SetLookRotation(new Vector3(0, 0, 0));
                    currentPage.eulerAngles = new Vector3(currentPage.eulerAngles.x, currentPage.eulerAngles.y,0);
                    
                    selectedPage--;
                    currentPage = gameObject.transform.GetChild(selectedPage).transform;

                   // StartCoroutine(TurnRight(0.75f));

                    Debug.Log("Pagina: " + gameObject.transform.GetChild(selectedPage).name);
                        //magazineOpenAngle -= 1;
                    }
              //  }
            }
        }
    }

    public void magazineSelection() {
        isSelected = true;

        Vector3 newPosition = controllerVisual.transform.position;
        Quaternion newRotation = controllerVisual.transform.rotation;
        this.gameObject.transform.position = new Vector3(newPosition.x, newPosition.y + pageSpacing, (newPosition.z + 0.5f));
        this.gameObject.transform.rotation = newRotation;
        this.gameObject.transform.SetParent(controllerVisual.transform.parent);
        //for (int i = 0; i < transform.childCount; i++) {
        //    transform.GetChild(i).gameObject.transform.position = new Vector3(newPosition.x, newPosition.y + pageSpacing, newPosition.z);
        //    transform.GetChild(i).gameObject.transform.rotation = newRotation;
        //}
    }

    public void printName()
    {
        Debug.Log(gameObject.name);
    }


    IEnumerator TurnRight(float time)
    {
        if (isFliping)
            yield break;

        isFliping = true;
        var startRotation = transform.rotation;
        var timer = 0.0f;

        while (timer <= 1.0f)
        {
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(currentPage.eulerAngles.x, currentPage.eulerAngles.y, (magazineOpenAngle - selectedPage)), timer);

            timer += Time.deltaTime / time;
            yield return null;
        }

        isFliping = false;
        selectedPage++;
        currentPage = gameObject.transform.GetChild(selectedPage).transform;
    }

    IEnumerator TurnLeft(float time)
    {
        if (isFliping)
            yield break;

        isFliping = true;
        var startRotation = transform.rotation;
        var timer = 0.0f;

        while (timer <= 1.0f)
        {
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(currentPage.eulerAngles.x, currentPage.eulerAngles.y, 0), timer);

            timer += Time.deltaTime / time;
            yield return null;
        }

        isFliping = false;
        selectedPage--;
        currentPage = gameObject.transform.GetChild(selectedPage).transform;
    }
}
