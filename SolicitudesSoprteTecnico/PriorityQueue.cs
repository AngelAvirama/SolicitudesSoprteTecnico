using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesSoprteTecnico
{
    public class PriorityQueue
    {
        private List<SolicitudSoporteTecnico> data;
        private Comparison<SolicitudSoporteTecnico> comparison;

        public PriorityQueue(Comparison<SolicitudSoporteTecnico> comparison)
        {
            this.data = new List<SolicitudSoporteTecnico>();
            this.comparison = comparison;
        }

        public int Count
        {
            get { return data.Count; }
        }

        public void Enqueue(SolicitudSoporteTecnico solicitud)
        {
            data.Add(solicitud);
            int childIndex = data.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (comparison(data[childIndex], data[parentIndex]) >= 0)
                    break;
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        public SolicitudSoporteTecnico Dequeue()
        {
            int lastIndex = data.Count - 1;
            SolicitudSoporteTecnico frontItem = data[0];
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);

            lastIndex--;
            int parentIndex = 0;
            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                if (leftChildIndex > lastIndex)
                    break;

                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && comparison(data[rightChildIndex], data[leftChildIndex]) < 0)
                    leftChildIndex = rightChildIndex;
                if (comparison(data[parentIndex], data[leftChildIndex]) <= 0)
                    break;

                Swap(parentIndex, leftChildIndex);
                parentIndex = leftChildIndex;
            }
            return frontItem;
        }

        private void Swap(int index1, int index2)
        {
            SolicitudSoporteTecnico temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }

        public SolicitudSoporteTecnico Peek()
        {
            if (data.Count > 0)
                return data[0];
            return default(SolicitudSoporteTecnico);
        }
    }
}
