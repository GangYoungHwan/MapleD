using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    [AddComponentMenu("UI/Effects/Letter Spacing", 14), RequireComponent(typeof(Text))]
#if UNITY_5_2 || UNITY_5_3
    public class LetterSpacing : BaseMeshEffect, ILayoutElement
#else
    public class LetterSpacing : BaseMeshEffect, ILayoutElement
#endif
    {
        [SerializeField]
        private float m_spacing = 0f;

        public float spacing
        {
            get { return this.m_spacing; }
            set
            {
                if (this.m_spacing == value) return;
                this.m_spacing = value;
                if (this.graphic != null) this.graphic.SetVerticesDirty();
                LayoutRebuilder.MarkLayoutForRebuild((RectTransform)this.transform);
            }
        }

        private Text text
        {
            get { return this.gameObject.GetComponent<Text>(); }
        }

        public float minWidth
        {
            get { return this.text.minWidth; }
        }

        public float preferredWidth
        {
            get { return this.text.preferredWidth + ((this.spacing * (float)this.text.fontSize / 100f) * (this.text.text.Length - 1)); }
        }

        public float flexibleWidth
        {
            get { return this.text.flexibleWidth; }
        }

        public float minHeight
        {
            get { return this.text.minHeight; }
        }

        public float preferredHeight
        {
            get { return this.text.preferredHeight; }
        }

        public float flexibleHeight
        {
            get { return this.text.flexibleHeight; }
        }

        public int layoutPriority
        {
            get { return this.text.layoutPriority; }
        }

        protected LetterSpacing() { }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            this.spacing = this.m_spacing;
            LayoutRebuilder.MarkLayoutForRebuild((RectTransform)this.transform);
        }
#endif

        public void CalculateLayoutInputHorizontal() { }
        public void CalculateLayoutInputVertical() { }

        private string[] GetLines()
        {
            IList<UILineInfo> lineInfos = text.cachedTextGenerator.lines;
            string[] lines = new string[lineInfos.Count];

            for (int i = 0; i < lineInfos.Count; i++)
            {
                if ((i + 1) < lineInfos.Count)
                {
                    lines[i] = this.text.text.Substring(lineInfos[i].startCharIdx, lineInfos[i + 1].startCharIdx - 1);
                }
                else
                {
                    lines[i] = this.text.text.Substring(lineInfos[i].startCharIdx);
                }
            }

            return lines;
        }

#if UNITY_5_2 || UNITY_5_3
        public override void ModifyMesh(Mesh mesh)
        {
            if (!this.IsActive())
                return;

            List<UIVertex> list = new List<UIVertex>();
            using (VertexHelper vertexHelper = new VertexHelper(mesh))
            {
                vertexHelper.GetUIVertexStream(list);
            }

            this.ModifyVertices(list);  // calls the old ModifyVertices which was used on pre 5.2

            using (VertexHelper vertexHelper2 = new VertexHelper())
            {
                vertexHelper2.AddUIVertexTriangleStream(list);
                vertexHelper2.FillMesh(mesh);
            }
        }
#endif
        public override void ModifyMesh(VertexHelper vh)
        {
            if (!this.IsActive())
                return;

            List<UIVertex> vertexList = new List<UIVertex>();
            vh.GetUIVertexStream(vertexList);

            ModifyVertices(vertexList);

            vh.Clear();
            vh.AddUIVertexTriangleStream(vertexList);
        }

        public void ModifyVertices(List<UIVertex> verts)
        {
            if (!this.IsActive()) return;

            string[] lines = this.GetLines();

            Vector3 pos;
            float letterOffset = this.spacing * (float)this.text.fontSize / 100f;
            float alignmentFactor = 0;
            int glyphIdx = 0;

            switch (this.text.alignment)
            {
                case TextAnchor.LowerLeft:
                case TextAnchor.MiddleLeft:
                case TextAnchor.UpperLeft:
                    alignmentFactor = 0f;
                    break;

                case TextAnchor.LowerCenter:
                case TextAnchor.MiddleCenter:
                case TextAnchor.UpperCenter:
                    alignmentFactor = 0.5f;
                    break;

                case TextAnchor.LowerRight:
                case TextAnchor.MiddleRight:
                case TextAnchor.UpperRight:
                    alignmentFactor = 1f;
                    break;
            }

            for (int lineIdx = 0; lineIdx < lines.Length; lineIdx++)
            {
                string line = lines[lineIdx];
                float lineOffset = ((line.Length - 1) * letterOffset) * alignmentFactor;

                for (int charIdx = 0; charIdx < line.Length; charIdx++)
                {
                    int idx1 = glyphIdx * 6 + 0;
                    int idx2 = glyphIdx * 6 + 1;
                    int idx3 = glyphIdx * 6 + 2;
                    int idx4 = glyphIdx * 6 + 3;
                    int idx5 = glyphIdx * 6 + 4;
                    int idx6 = glyphIdx * 6 + 5;

                    // Check for truncated text (doesn't generate verts for all characters)
                    if (idx6 > verts.Count - 1) return;

                    UIVertex vert1 = verts[idx1];
                    UIVertex vert2 = verts[idx2];
                    UIVertex vert3 = verts[idx3];
                    UIVertex vert4 = verts[idx4];
                    UIVertex vert5 = verts[idx5];
                    UIVertex vert6 = verts[idx6];

                    pos = Vector3.right * ((letterOffset * charIdx) - lineOffset);

                    vert1.position += pos;
                    vert2.position += pos;
                    vert3.position += pos;
                    vert4.position += pos;
                    vert5.position += pos;
                    vert6.position += pos;

                    verts[idx1] = vert1;
                    verts[idx2] = vert2;
                    verts[idx3] = vert3;
                    verts[idx4] = vert4;
                    verts[idx5] = vert5;
                    verts[idx6] = vert6;

                    glyphIdx++;
                }

                // Offset for carriage return character that still generates verts
                glyphIdx++;
            }
        }
    }
}
