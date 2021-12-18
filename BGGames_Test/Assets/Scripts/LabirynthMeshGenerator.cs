using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class LabirynthMeshGenerator
    {
        private LabirynthSettings _labirinthSettings;


        public LabirynthMeshGenerator(LabirynthSettings labirynthSettings)
        {
            _labirinthSettings = labirynthSettings;
        }

        public Mesh GenerateMeshFromData(int[,] data)
        {
            Mesh labirynth = new Mesh();

            List<Vector3> newVertices = new List<Vector3>();
            List<Vector2> newUVs = new List<Vector2>();

            labirynth.subMeshCount = 2;
            List<int> floorTriangles = new List<int>();
            List<int> wallTriangles = new List<int>();

            int maxRows = data.GetUpperBound(0);
            int maxColumns = data.GetUpperBound(1);
            float halfH = _labirinthSettings.WallHeight * .5f;

            for (int i = 0; i <= maxRows; i++)
            {
                for (int j = 0; j <= maxColumns; j++)
                {
                    if (data[i, j] != 1)
                    {
                        // floor
                        AddQuad(Matrix4x4.TRS(
                            new Vector3(j * _labirinthSettings.CorridorWidth, 0, i * _labirinthSettings.CorridorWidth),
                            Quaternion.LookRotation(Vector3.up),
                            new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.CorridorWidth, 1)
                        ), ref newVertices, ref newUVs, ref wallTriangles);

                        // walls

                        if (i - 1 < 0 || data[i - 1, j] == 1)
                        {
                            AddQuad(Matrix4x4.TRS(
                                new Vector3(j * _labirinthSettings.CorridorWidth, halfH, (i - .5f) * _labirinthSettings.CorridorWidth),
                                Quaternion.LookRotation(Vector3.forward),
                                new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.WallHeight, 1)
                            ), ref newVertices, ref newUVs, ref wallTriangles);
                        }

                        if (j + 1 > maxColumns || data[i, j + 1] == 1)
                        {
                            AddQuad(Matrix4x4.TRS(
                                new Vector3((j + .5f) * _labirinthSettings.CorridorWidth, halfH, i * _labirinthSettings.CorridorWidth),
                                Quaternion.LookRotation(Vector3.left),
                                new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.WallHeight, 1)
                            ), ref newVertices, ref newUVs, ref wallTriangles);
                        }

                        if (j - 1 < 0 || data[i, j - 1] == 1)
                        {
                            AddQuad(Matrix4x4.TRS(
                                new Vector3((j - .5f) * _labirinthSettings.CorridorWidth, halfH, i * _labirinthSettings.CorridorWidth),
                                Quaternion.LookRotation(Vector3.right),
                                new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.WallHeight, 1)
                            ), ref newVertices, ref newUVs, ref wallTriangles);
                        }

                        if (i + 1 > maxRows || data[i + 1, j] == 1)
                        {
                            AddQuad(Matrix4x4.TRS(
                                new Vector3(j * _labirinthSettings.CorridorWidth, halfH, (i + .5f) * _labirinthSettings.CorridorWidth),
                                Quaternion.LookRotation(Vector3.back),
                                new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.WallHeight, 1)
                            ), ref newVertices, ref newUVs, ref wallTriangles);
                        }
                    }
                    else
                    {
                        // wall top
                        AddQuad(Matrix4x4.TRS(
                            new Vector3(j * _labirinthSettings.CorridorWidth, _labirinthSettings.WallHeight, i * _labirinthSettings.CorridorWidth),
                            Quaternion.LookRotation(Vector3.up),
                            new Vector3(_labirinthSettings.CorridorWidth, _labirinthSettings.CorridorWidth, 1)
                        ), ref newVertices, ref newUVs, ref wallTriangles);
                    }
                }
            }

            labirynth.vertices = newVertices.ToArray();
            labirynth.uv = newUVs.ToArray();
            labirynth.triangles = wallTriangles.ToArray();

            labirynth.RecalculateNormals();

            return labirynth;
        }

        private void AddQuad(Matrix4x4 matrix, ref List<Vector3> newVertices,
            ref List<Vector2> newUVs, ref List<int> newTriangles)
        {
            int index = newVertices.Count;

            Vector3 vert1 = new Vector3(-0.5f, -0.5f, 0);
            Vector3 vert2 = new Vector3(-0.5f, 0.5f, 0);
            Vector3 vert3 = new Vector3(0.5f, 0.5f, 0);
            Vector3 vert4 = new Vector3(0.5f, -0.5f, 0);

            newVertices.Add(matrix.MultiplyPoint3x4(vert1));
            newVertices.Add(matrix.MultiplyPoint3x4(vert2));
            newVertices.Add(matrix.MultiplyPoint3x4(vert3));
            newVertices.Add(matrix.MultiplyPoint3x4(vert4));

            newUVs.Add(new Vector2(1, 0));
            newUVs.Add(new Vector2(1, 1));
            newUVs.Add(new Vector2(0, 1));
            newUVs.Add(new Vector2(0, 0));

            newTriangles.Add(index + 2);
            newTriangles.Add(index + 1);
            newTriangles.Add(index);

            newTriangles.Add(index + 3);
            newTriangles.Add(index + 2);
            newTriangles.Add(index);
        }
    }
}