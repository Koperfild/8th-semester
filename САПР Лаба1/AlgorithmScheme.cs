using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_Laba1
{
    public class AlgorithmScheme
    {
        List<Page> pages;
        Form1 f;
        public AlgorithmScheme(byte[][] IncidenceMatrix,Form1 f1)
        {
            pages = new List<Page>();
            f = f1;
            Calc();
        }
        public class Page
        {
            public List<Node> graphSymbols;
            public int number;
        }
        public class Node
        {
            public Page page;
            public string text;
            public List<Node> outgoingNodes;
            public List<Node> incomingNodes;
            public NodeType type;
            public enum NodeType { Terminator, Data, Cycle, Solution }
        }
        
        public void Calc(byte[][] IncidenceMatrix)
        {
            List<Node> nodes = new List<Node>();
            //Делаем список всех узлов
            for (int i=0;i<IncidenceMatrix.Length;i++)
                nodes.Add(new Node());

            //По матрице инцидентности прописываем связи между узлами
            for (int i = 0; i < IncidenceMatrix.Length; i++)
            {
                
                for (int j = 0; j < IncidenceMatrix[i].Length; j++)
                {
                    if (IncidenceMatrix[i][j] == 1)
                    {
                        nodes[i].outgoingNodes.Add(nodes[j]);
                        nodes[j].incomingNodes.Add(nodes[i]);
                    }
                }
            }

            //Вводим начальный узел (стартовый)
            int beginnodeNumber = Begi;

            !!!!!!!!-Делать ввод с формы номера начального узла!!!!!!
            int.TryParse(Console.ReadLine(), out beginnodeNumber);
            Node beginNode = nodes[beginnodeNumber];
            int nodeQuantity = IncidenceMatrix.Length;
            //p-макс кол-во граф символов на страницу
            int p;

            //Тут короче сделать округление в большую сторону
            //l- число страниц, вроде как не нужно.Закомменчу
            //int l = (double)nodeQuantity / (double)p;

            this.pages = splitNodesToPages(beginNode, p);
            //Счётчик страниц
            //int k = 1;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginNode">Начальный узел</param>
        /// <param name="p">Макс число граф символов на страницу</param>
        /// <returns></returns>
        public List<Page> splitNodesToPages(Node beginNode, int p)
        {
            if (p < 1)
                throw new Exception("Wrong max count of graph symbols per page");
            if (beginNode == null)
                throw new Exception("Not specified beginNode");
            //Создаём первую страницу
            List<Page> pages = new List<Page>();
            Page firstpage = new Page();
            int number = 0;
            firstpage.number = number;
            //Добавляем на первую страницу начальный узел
            firstpage.graphSymbols.Add(beginNode);
            pages.Add(firstpage);

            //Текущая страница
            Page currPage = firstpage;
            List<Node> currPageAssociatedNodes;//Внешние узлы связанные с текущей страницей
            Node maxKcvNode;

            //Цикл пока есть нераспределённые внешние узлы, связанные с текущей страницей
            while ((currPageAssociatedNodes = getListOfAssociatedNodes(currPage)).Count > 0)
            {
                maxKcvNode = currPageAssociatedNodes.Max<Node>();

                /*
                //Сортируем внешние узлы связанные с текущей страницей по их Ксв (коэф-т связности)
                currPageAssociatedNodes.Sort((Node x, Node y) =>
                {
                    if (x == null && y == null) return 0;
                    else if (x == null) return -1;
                    else if (y == null) return 1;
                    else return Kcv(currPage, x).CompareTo(Kcv(currPage, y));
                });
                */

                if (currPage.graphSymbols.Count == p)
                {
                    //Увеличиваем текущий номер страницы
                    number++;
                    //Создаём новую страницу
                    currPage = new Page()
                    {
                        number = number,
                        //Добавляем на эту страницу внеш. граф символ с макс Ксв для предыдущей страницы
                        graphSymbols = new List<Node>()
                        {
                            maxKcvNode
                        }
                    };
                    pages.Add(currPage);
                    continue;
                }
                else
                    //Добавляем к граф символам текущей страницы внешний граф символ связанныq с текущей страницей с макс Ксв
                    currPage.graphSymbols.Add(maxKcvNode);
            }
            return pages;
        }
        
        public IEnumerable<int> m

        /// <summary>
        /// Функция расчёта коэффициента связности. В моей интерпретации проверяется связь не со всеми страницами а лишь с текущей, т.е. будет другая d+. d+ включает лишь связи с текущей страницей.
        /// </summary>
        /// <param name="currentnode">Узел для которого рассчитывается коэффициент</param>
        /// <param name="page"></param>
        /// <returns>Коэф-т связности 0<=Kcv<=1</returns>
        public double Kcv(Page currpage, Node nodetocalc)
        {
            int AllNodeAssociationsQuantity = nodetocalc.outgoingNodes.Count + nodetocalc.incomingNodes.Count;
            int dplus=0;
            for (int i=0;i<nodetocalc.incomingNodes.Count;i++)
            {
                if (nodetocalc.incomingNodes[i].page == currpage)
                    dplus += 1;

            }
            for (int i=0;i<nodetocalc.outgoingNodes.Count;i++)
            {
                if (nodetocalc.outgoingNodes[i].page == currpage)
                    dplus += 1;
            }
            return (double)dplus / AllNodeAssociationsQuantity;
        }
        /// <summary>
        /// Получает список связанных со всеми узлами страницы внешних узлов. Нужно для включения внешних узлов с макс Ксв в эту страницу
        /// </summary>
        /// <param name="pages">Тут подумать. Вроде только одна страница нужна.   Список страниц, для узлов которых ищутся внешние узлы (вне этих страниц) если таковые имеются (остались неразбросанные по страницам узлы)</param>
        /// <returns>Список внешних узлов связанных со страницей</returns>
        public List<Node> getListOfAssociatedNodes(Page page)
        {
            //Список внешних узлов связанных со страницей
            List<Node> outFromPageNodes = new List<Node>();
            //Проходимся по всем узлам текущей страницы
            for (int i=0;i<page.graphSymbols.Count;i++)
            {
                //Проходимся по всем исходящим связям узла
                for (int j=0;j<page.graphSymbols[i].outgoingNodes.Count;j++)
                {
                    //если графсимвол связанный с текущим графсимволом принадлежит какой-либо странице,то пропускаем, т.к. ищем только внешние узлы
                    if (page.graphSymbols[i].outgoingNodes[j].page != null)
                        continue;
                    outFromPageNodes.Add(page.graphSymbols[i].outgoingNodes[j]);
                }
            }
            return outFromPageNodes;
        }        
    }
}
