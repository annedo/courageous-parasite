using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject FleshSpriteRendererPrefab;
    public Texture2D SkinTexture;
    public GameObject FleshBlobTray;
    public Text MoneyText;
    public Text TimerText;
    public double CurrentMoney = 0;

    private SpriteRenderer fleshBlobTrayRenderer;
    // Start is called before the first frame update
    void Start()
    {
        fleshBlobTrayRenderer = FleshBlobTray.GetComponent<SpriteRenderer>();
        fleshBlobTrayRenderer.enabled = false;
    }

    private GameObject drawer;
    private LineRenderer lineRenderer;
    private float Timer = 0f;
    private int CurrentTime = 0;    
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        CurrentTime = GameModel.SKIN_GAME_TIME_LIMIT - (int)Math.Round(Timer % 60, 0);

        MoneyText.text = string.Format("{0}{1:N2}", GameModel.CurrencySymbol, CurrentMoney);
        TimerText.text = CurrentTime.ToString();

        if (CurrentTime <= 0)
        {
            GameModel.CurrentMoney += CurrentMoney;
            SceneManager.LoadScene("MainScene");
        }
    }

    private void CreateFleshSprite()
    {
        // Create new sprite
        var spriteRendererHolder = Instantiate(FleshSpriteRendererPrefab);
        var spriteRenderer = spriteRendererHolder.GetComponent<SpriteRenderer>();
        var fleshPiece = Sprite.Create(SkinTexture, new Rect(0, 0, SkinTexture.width, SkinTexture.height), Vector2.zero, 100);
        ChangeSprite(fleshPiece, GetLineVertices(lineRenderer));
        spriteRenderer.sprite = fleshPiece;
    }

    private void FreeDraw()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(mousePos));

        // TODO - if any lines intercept, delete drawer
    }

    private bool LineIsEncapsulated(Vector3 firstVector, Vector3 lastVector)
    {
        if (firstVector.x.IsBasicallyEqual(lastVector.x)
            && firstVector.y.IsBasicallyEqual(lastVector.y))
            return true;

        return false;
    }

    private Vector2[] GetLineVertices(LineRenderer line)
    {
        var vectors = new Vector2[line.positionCount];

        for (int i = 0; i < line.positionCount; i ++)
        {
            var currentVector = line.GetPosition(i);
            vectors[i] = new Vector2(currentVector.x, currentVector.y);
        }

        return vectors;
    }

    // Edit the vertices obtained from the sprite.  Use OverrideGeometry to
    // submit the changes.
    private void ChangeSprite(Sprite sprite, Vector2[] newVertices)
    {
        Vector2[] vertices = sprite.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x = Mathf.Clamp(
                (newVertices[i].x - sprite.bounds.center.x -
                    (sprite.textureRectOffset.x / sprite.texture.width) + sprite.bounds.extents.x) /
                (2.0f * sprite.bounds.extents.x) * sprite.rect.width,
                0.0f, sprite.rect.width);

            vertices[i].y = Mathf.Clamp(
                (newVertices[i].y - sprite.bounds.center.y -
                    (sprite.textureRectOffset.y / sprite.texture.height) + sprite.bounds.extents.y) /
                (2.0f * sprite.bounds.extents.y) * sprite.rect.height,
                0.0f, sprite.rect.height);
        }

        sprite.OverrideGeometry(vertices, sprite.triangles);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            drawer = Instantiate(LinePrefab);
            lineRenderer = drawer.GetComponent<LineRenderer>();
        }
        else if (Input.GetMouseButton(0))
        {
            if (lineRenderer != null)
                FreeDraw();
        }
        else
        {
            if (lineRenderer == null)
                return;

            if (LineIsEncapsulated(lineRenderer.GetPosition(0), lineRenderer.GetPosition(lineRenderer.positionCount - 1)))
            {
                fleshBlobTrayRenderer.enabled = true;
                CurrentMoney += GameModel.SKIN_GAME_MONEY_PER_PIECE;
                FleshBlobTray.transform.localScale += new Vector3(0.5f, 0.5f);
                //CreateFleshSprite();
            }

            Destroy(drawer);
        }
    }

    private void OnMouseExit()
    {
        Destroy(drawer);
    }
}
