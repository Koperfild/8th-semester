using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_Laba1
{
    public class AlgorithmScheme
    {
        public static List<Page> pages { get; set; }
        public AlgorithmScheme() { }
        public AlgorithmScheme(int[,] IncidenceMatrix, int beginNodeNumber, int p)
        {
            
            Calc(IncidenceMatrix, beginNodeNumber, p);
        }
        public class Page
        {
            public List<Node> graphSymbols;
            public int number;
            public Page()
            {
                graphSymbols = new List<Node>();
            }
        }
        public class Node
        {
            public Page page;
            public int ID;
            public string text;
            public List<Node> outgoingNodes;
            public List<Node> incomingNodes;
            public double Kcv; //Ксв перед добавлением граф символа на страницу. Пришлось ввести,т.к. нужно потом при выводе результатов. При этом Ксв нельзя соотнести с узлом. Каждый раз Ксв разный, поэтому не хотел вводить это поле
            public Node()
            {
                outgoingNodes = new List<Node>();
                incomingNodes = new List<Node>();
            }
            public NodeType type;
            public enum NodeType { Terminator, Data, Cycle, Solution }
            public static Node MaxNode(List<Node> nodes, Page currPage)
            {
                if (nodes.Count == 0 || nodes == null)
                    return null;

                Node maxNode = nodes[0];
                double kcv1, kcv2;
                for (int i = 0; i < nodes.Count; i++)
                {

                    if ( (kcv1=AlgorithmScheme.Kcv(currPage, nodes[i])) > (kcv2=AlgorithmScheme.Kcv(currPage,maxNode)))
                        maxNode = nodes[i];
                    else if (kcv1 == kcv2)
                    {
                        int currNodeAssociations = nodes[i].incomingNodes.Count + nodes[i].outgoingNodes.Count;
                        int maxNodeAssociations = maxNode.incomingNodes.Count + maxNode.outgoingNodes.Count;

                        if (kcv1 > 0.5)
                            if (currNodeAssociations > maxNodeAssociations)
                                maxNode = nodes[i];

                        if (kcv1 < 0.5)
                            if (currNodeAssociations < maxNodeAssociations)
                                maxNode = nodes[i];
                        //if kcv1== 0.5не меняем maxNode
                    }
                }
                return maxNode;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenceMatrix"></param>
        /// <param name="beginNodeNumber"></param>
        /// <param name="p">Max graph symbols count per page</param>
        public void Calc(int[,] IncidenceMatrix, int beginNodeNumber, int p)
        {
            List<Node> nodes = new List<Node>();
            //Делаем список всех узлов
            for (int i = 0; i < IncidenceMatrix.GetLength(1); i++)
                //for (int j=0;j<IncidenceMatrix.GetLength(1);j++)
                //Присваиваем каждому узлу ID в соответствие с матрицей инцидентности
                nodes.Add(new Node() { ID = i });

            //По матрице инцидентности прописываем связи между узлами
            for (int i = 0; i < IncidenceMatrix.GetLength(0); i++)
            {
                
                for (int j = 0; j < IncidenceMatrix.GetLength(1); j++)
                {
                    if (IncidenceMatrix[i,j] == 1)
                    {
                        nodes[i].outgoingNodes.Add(nodes[j]);
                        nodes[j].incomingNodes.Add(nodes[i]);
                    }
                }
            }

            //Вводим начальный узел (стартовый)
            Node beginNode = nodes[beginNodeNumber];
            try
            {
                pages = splitNodesToPages(beginNode, p);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginNode">Начальный узел</param>
        /// <param name="p">Макс число граф символов на страницу</param>
        /// <returns></returns>
        public List<Page> splitNodesToPages(Node beginNode, int p)
        {
            
            //Создаём первую страницу
            List<Page> pages = new List<Page>();
            Page firstpage = new Page();
            int number = 0;
            firstpage.number = number;
            beginNode.page = firstpage;
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
                maxKcvNode = Node.MaxNode(currPageAssociatedNodes, currPage);
                //Добавляем в граф символ посчитанный Ксв. Можно и в Node.MaxNode, но делаю тут для явности
                maxKcvNode.Kcv = Kcv(currPage, maxKcvNode);
               //Если число символов на странице достигло максимума
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
                    maxKcvNode.page = currPage;
                    pages.Add(currPage);
                    continue;
                }
                else
                {
                    maxKcvNode.page = currPage;
                    //Добавляем к граф символам текущей страницы внешний граф символ связанныq с текущей страницей с макс Ксв
                    currPage.graphSymbols.Add(maxKcvNode);
                }
            }
            //Если первая страница получилась несвязанной ни с чем и на ней только начальный граф символ
            if (pages.Count == 1 && pages[0].graphSymbols[0].incomingNodes.Count ==0 && pages[0].graphSymbols[0].outgoingNodes.Count ==0)
                throw new Exception("Введена пустая или несвязная граф схема");
            return pages;
        }
        
        /// <summary>
        /// Функция расчёта коэффициента связности. В моей интерпретации проверяется связь не со всеми страницами а лишь с текущей, т.е. будет другая d+. d+ включает лишь связи с текущей страницей.
        /// </summary>
        /// <param name="currentnode">Узел для которого рассчитывается коэффициент</param>
        /// <param name="page"></param>
        /// <returns>Коэф-т связности 0<=Kcv<=1</returns>
        public static double Kcv(Page currpage, Node nodetocalc)
        {
            //int AllNodeAssociationsQuantity = nodetocalc.outgoingNodes.Count + nodetocalc.incomingNodes.Count;
            int dminus = 0;//dminus спорно как считать в учебнике картинка противоречит. Там просто Е\Ек а не сумма Еr по r=1..к
            int dplus=0;
            for (int i=0;i<nodetocalc.incomingNodes.Count;i++)
            {
                if (nodetocalc.incomingNodes[i].page == null)
                    dminus += 1;
                else if (nodetocalc.incomingNodes[i].page == currpage)
                    dplus += 1;
            }
            for (int i=0;i<nodetocalc.outgoingNodes.Count;i++)
            {
                if (nodetocalc.outgoingNodes[i].page == null)
                    dminus += 1;
                if (nodetocalc.outgoingNodes[i].page == currpage)
                    dplus += 1;
            }
            double res;
            res = (double)dplus / (double)(dminus+dplus);
            return res;
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
                    if (page.graphSymbols[i].outgoingNodes[j].page == null)
                        outFromPageNodes.Add(page.graphSymbols[i].outgoingNodes[j]);
                }
                for (int j = 0; j < page.graphSymbols[i].incomingNodes.Count; j++)
                    if (page.graphSymbols[i].incomingNodes[j].page == null)
                        outFromPageNodes.Add(page.graphSymbols[i].incomingNodes[j]);

            }
            return outFromPageNodes;
        }
    }
}
