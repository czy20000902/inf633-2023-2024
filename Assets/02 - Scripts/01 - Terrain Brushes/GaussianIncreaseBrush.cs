using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianIncreaseBrush : TerrainBrush {

    public float intensity = 50.0f;
    public float spread = 3.0f;

    public override void draw(int x, int z) {
        for (int zi = -radius; zi <= radius; zi++) {
            for (int xi = -radius; xi <= radius; xi++) {
                float height = terrain.get(x + xi, z + zi);

                float distance = Mathf.Sqrt(xi * xi + zi * zi);

                float gauss = Mathf.Exp(-(distance * distance) / (2.0f * spread * spread));

                terrain.set(x + xi, z + zi, gauss * intensity);
            }
        }
    }
}
