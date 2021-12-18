using UnityEngine;

namespace BGGames_Test
{
    public class LabirynthGenerator
    {
        private Labirynth _labirynth;
        private LabirynthDataGenerator _dataGenerator;
        private LabirynthMeshGenerator _meshGenerator;

        private int[,] _labirynthData;

        public LabirynthGenerator(Labirynth labirynth)
        {
            _labirynth = labirynth;

            _dataGenerator = new LabirynthDataGenerator(_labirynth.Settings);
            _meshGenerator = new LabirynthMeshGenerator(_labirynth.Settings);
        }

        public void GenerateLabirynth()
        {
            _labirynthData = _dataGenerator.GenerateData();

            GameObject go = new GameObject();
            go.transform.position = Vector3.zero;
            go.name = "LabirinthWalls";

            MeshFilter mf = go.AddComponent<MeshFilter>();
            mf.mesh = _meshGenerator.GenerateMeshFromData(_labirynthData);

            MeshCollider mc = go.AddComponent<MeshCollider>();
            mc.sharedMesh = mf.mesh;

            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.materials = new Material[1] { _labirynth.Settings.Material };

            go.transform.SetParent(_labirynth.transform);
        }
    }
}