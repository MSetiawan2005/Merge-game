using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TileElementMisi : MonoBehaviour
{

    bool MoveWithMouse = false;
    bool CollidedWithOther = false;

    [SerializeField] private AudioSource margeSound;
    [SerializeField] private AudioSource swapSound;

    MissionTileMap TM;
    MissionBoard TSM;
    Stack Sprites;
    GameObject triggered;
    GameUI1 gm;

   // public Text textScore;
    public int increaseScore;
    int score;
    //public Text textScore;

    //public Text finalScore;

   

    
    // Use this for initialization
    void Awake()
    {
        TM = FindObjectOfType<MissionTileMap>();
        TSM = FindObjectOfType<MissionBoard>();
   
    }
    void Update()
    {
        if (MoveWithMouse && GetComponent<SpriteRenderer>().enabled)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }
    void OnMouseDown()
    {
        MoveWithMouse = true;
    }
    void OnMouseUp()
    {
        MoveWithMouse = false;
        if (CollidedWithOther)
        {
            OntoOtherOne();
        }
        else
        {
            BackToParent();
        }       
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<TileElementMisi>())
        {
            triggered = col.gameObject;
            CollidedWithOther = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<TileElementMisi>() )
        {
            CollidedWithOther = false;
        }
    }
    void OntoOtherOne()
    {
        if(triggered.GetComponent<TileElementMisi>().Sprites.Count == Sprites.Count && Sprites.Count !=0 )
        {
            Merge();
            margeSound.Play();

            GameUI1.scoreCount += increaseScore;
            //textScore.text = score.ToString();
           
        }
        else
        {
            Swap();
            swapSound.Play();
        }
    }
    void Merge()
    {
        triggered.GetComponent<TileElementMisi>().UpdateTileElementSprite();
        Hide();
    }
    void Hide()
    {
        BackToParent();
        ResetStack();
        Appear(false);
        TM.EmptyTile(this);
    }    
    void Swap()
    {
        Transform parent = triggered.transform.parent;
        triggered.transform.parent = this.transform.parent;
        this.transform.parent = parent;
        triggered.GetComponent<TileElementMisi>().BackToParent();
        BackToParent();
    }
    public void Appear(bool enable)
    {
        GetComponent<SpriteRenderer>().enabled = enable;
        if (enable)
        {
            UpdateTileElementSprite();
        }
    }
     void UpdateTileElementSprite()
    {
        GetComponent<SpriteRenderer>().sprite = (Sprite)Sprites.Pop();
    }
    public void InitTileElement()
    {
        ResetStack();
        BackToParent();
        Appear(false);
        GetComponent<BoxCollider2D>().size = ((Sprite)Sprites.Peek()).bounds.size;
    }
    void ResetStack()
    {
        Sprites = TSM.GetTileSpritesStack();
    }
    void BackToParent()
    {
        this.transform.position = transform.parent.position;
    }
}
