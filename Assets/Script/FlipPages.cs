using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPages : MonoBehaviour
{
    private enum Pages
    {
        Cover,
        Page1,
        Page2,
        Back
    }

    public enum MagazineType {
        Skills,
        Guns
    }

    public GameObject controllerVisual;
    public float pageSpacing;

    public MagazineType magazineType;

    private bool isSelected;

    private float startPosition;
    private float endPosition;

    private int selectedPage;
    private Transform currentPage;

    // Use this for initialization
    void Start()
    {
        selectedPage = (int)Pages.Cover;
        currentPage = gameObject.transform.GetChild(selectedPage).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            if (GvrControllerInput.TouchDown)
            {
                startPosition = GvrControllerInput.TouchPosCentered.x;
            }
            if (GvrControllerInput.TouchUp)
            {
                if (GvrControllerInput.TouchPosCentered.x < startPosition)
                {

                    Debug.Log("Swipe Left");
                    currentPage.GetComponent<Animator>().SetBool("flip", true);

                    selectedPage++;
                    currentPage = gameObject.transform.GetChild(selectedPage).transform;

                }
                else if (GvrControllerInput.TouchPosCentered.x > startPosition)
                {
                    Debug.Log("Swipe Right");
                    currentPage.GetComponent<Animator>().SetBool("flip", false);

                    selectedPage--;
                    currentPage = gameObject.transform.GetChild(selectedPage).transform;
                }
            }
        }
    }

    public void magazineSelection()
    {
        if (!isSelected)
        {
            isSelected = true;

            Vector3 newPosition = controllerVisual.transform.position;

            Quaternion newRotation = controllerVisual.transform.rotation;
            this.gameObject.transform.position = new Vector3(newPosition.x, newPosition.y + pageSpacing, (newPosition.z));
            this.gameObject.transform.rotation = newRotation;
            this.gameObject.transform.SetParent(controllerVisual.transform.parent);
        }
    }
}
