using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour
{
    public static Game Instance
    {
        get; private set;
    }

    private Player player;

    private List<Enemy> enemies;

    private List<Projectile> projectiles;

    private Texture2D pixel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pixel = new Texture2D(1, 1);
        pixel.SetPixel(0, 0, Color.white);
        pixel.Apply();

        player = new Player();

        enemies = new List<Enemy>();
        for(int i = 0; i < 1; ++i)
        {
            enemies.Add(new Enemy(new DevMath.Vector2(Random.Range(.0f, Screen.width), Random.Range(.0f, Screen.height))));
        }

        projectiles = new List<Projectile>();
    }

    private void OnGUI()
    {
        player?.Render();

        enemies.ForEach(e => e.Render());

        projectiles.ForEach(p => p.Render());

        if(player == null)
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = new Color(Mathf.Sin(Time.time * 2), Mathf.Sin(Time.time * 1.5f), Mathf.Sin(Time.time), DevMath.DevMath.Lerp(0.5f, 1.0f, Mathf.Sin(Time.time)));
            style.fontSize = 75;
            style.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(Screen.width * .5f - 50.0f, Screen.height * .5f - 75.0f, 100.0f, 100.0f), "YOU LOSE!", style);
        }
        else
		{
            if (Input.GetKey(KeyCode.Q))
            {
                

                foreach (var enemy in enemies)
                {
                    var direction = enemy.Position - player.Position;
                    var distance = direction.Magnitude;

                    var a = DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(new DevMath.Vector2(0, 0), direction));
                    GUIUtility.RotateAroundPivot(a, player.Position.ToUnityVector2());

                    GUI.color = Color.magenta;

                    GUI.DrawTexture(new Rect(player.Position.x, player.Position.y, distance, 1), pixel);

                    GUI.matrix = Matrix4x4.identity;

                    GUI.color = Color.black;

                    var dot = DevMath.Vector2.Dot(direction.Normalized, player.Direction);

                    var textPos = player.Position + DevMath.Vector2.DirectionFromAngle(a) * (distance * .5f);
                    GUI.Label(new Rect(textPos.x, textPos.y, 200.0f, 200.0f), $"Distance: {distance}\nAngle: {a}\nDot: {dot}");
                }

                GUI.color = Color.white;
            }
		}
    }

    public void CreateProjectile(DevMath.Vector2 position, DevMath.Vector2 direction, float startVelocity, float acceleration)
    {
        projectiles.Add(new Projectile(position, direction, startVelocity, acceleration));
    }

    private void Update()
    {
        if (player == null) return;

        player.Update();

        enemies.ForEach(e => e.Update(player));

        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            projectiles[i].Update();
            if(projectiles[i].ShouldDie)
            {
                projectiles.RemoveAt(i);
            }
        }

        foreach(Enemy e in enemies)
        {
            if(e.Circle.CollidesWith(player.Circle))
            {
                player = null;
            }
        }

        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            for(int j = enemies.Count - 1; j >= 0; --j)
            {
                if(projectiles[i].Circle.CollidesWith(enemies[j].Circle))
                {
                    enemies.RemoveAt(j);
                    projectiles.RemoveAt(i);
                    break;
                }
            }
        }

        if(enemies.Count == 0)
            enemies.Add(new Enemy(new DevMath.Vector2(Random.Range(.0f, Screen.width), Random.Range(.0f, Screen.height))));

        if(player != null)
            player.Intersecting = enemies.Any(e => player.line.IntersectsWith(e.Circle));
    }
}
