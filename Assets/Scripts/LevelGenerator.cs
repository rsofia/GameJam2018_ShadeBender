using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public static Texture2D map;

    public ColorToPrefab[] colorMappings;

    void Start() {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int _x, int _y)
    {
        Color pixelColor = map.GetPixel(_x, _y);

        if (pixelColor.a == 0)
            return;
        Debug.Log("RGB AQUI");
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Instantiate(colorMapping.Prefab, new Vector2(_x, _y), Quaternion.identity, transform);
                Debug.Log("YES");
            }
        }
    }
}
