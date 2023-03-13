using System.Data;
using System.Reflection;
using LitJson;


namespace FormulationQuantification
{
    public partial class MainForm : Form
    {
        List<Item> items = new List<Item>();
        string[] itemsName;
        public MainForm()
        {
            InitializeComponent();
            parentNode = formulaTreeView.Nodes;

        }
        /// <summary>
        /// 通过json配置 让item全部实例化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            string json = String.Empty;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetName().Name.ToString() + ".Formula.json";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    json = sr.ReadToEnd();
                }
            }
            JsonData jsonData = JsonMapper.ToObject(json);
            foreach (JsonData temp in jsonData)
            {
                List<Formula> FormulaList = new();
                //通过字符串索引器可以取得键值对的值
                JsonData nameValue = temp["name"];
                JsonData factoryValue = temp["factory"];
                JsonData formulasValue = temp["formulas"];
                if (formulasValue != null)
                {
                    foreach (JsonData formula in formulasValue)
                    {
                        JsonData formulaItemValue = formula["item"];
                        JsonData formulaNumValue = formula["num"];
                        string formulaItem = formulaItemValue.ToString();
                        int formulaNum = int.Parse(formulaNumValue.ToString());
                        Item tmpItem = items.Find(c => c.Name.Equals(formulaItem));
                        if (tmpItem != null)
                        {
                            FormulaList.Add(new Formula(tmpItem, formulaNum));
                        }
                    }
                }
                JsonData numValue = temp["num"];
                string name = nameValue.ToString();
                string factory = factoryValue.ToString();
                int num = int.Parse(numValue.ToString());
                items.Add(new Item(name, factory, FormulaList, num));

            }
            itemsName = new string[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                itemsName[i] = items[i].Name;
            }
            itemComboBox.Items.AddRange(itemsName);
        }

        List<Factory> finalFormulas = new();
        TreeNodeCollection parentNode;
        Item tmpItem;
        /// <summary>
        /// 量化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quantification(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(itemComboBox.Text) || String.IsNullOrEmpty(numTextBox.Text))
            {
                formulaListBox.Items.Add(System.DateTime.Now + ": 没有选择量化物品或者填写数量！");
                return;
            }
            formulaTreeView.Nodes.Clear();
            parentNode = formulaTreeView.Nodes;
            string itemName = itemComboBox.Text;
            int num = int.Parse(numTextBox.Text);

            tmpItem = items.Find(c => c.Name.Equals(itemName));
            QuantificationFactory(tmpItem, num);
            formulaTreeView.ExpandAll();
        }
        /// <summary>
        /// 量化item与factory的生产关系
        /// </summary>
        /// <param name="item"></param>
        /// <param name="num"></param>
        public void QuantificationFactory(Item item, float num)
        {
            float factoryNum = num / item.Num;
            finalFormulas.Add(new Factory(item.Name, num, item.Factory, factoryNum));
            TreeNode treeNode = new TreeNode
            {
                Text = "[" + item.Name + ":" + num + "],  [" + item.Factory + ":" + factoryNum + "]"
            };
            parentNode.Add(treeNode);

            if (item.Formulas.Count == 0)
            {
                return;
            }
            else
            {
                parentNode = treeNode.Nodes;
                foreach (Formula i in item.Formulas)
                {
                    QuantificationFactory(i.Item, i.Num * factoryNum);
                    parentNode = treeNode.Nodes;
                }

            }

        }
        private void SelectItem(object sender, EventArgs e)
        {
            var input = itemComboBox.Text.ToUpper();
            itemComboBox.Items.Clear();
            if (string.IsNullOrWhiteSpace(input))
                itemComboBox.Items.AddRange(itemsName);
            else
            {
                var newList = itemsName.Where(x => x.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) != -1).ToArray();
                itemComboBox.Items.AddRange(newList);
            }
            itemComboBox.Select(itemComboBox.Text.Length, 0);
            itemComboBox.DroppedDown = true;
            //保持鼠标指针形状  
            Cursor = Cursors.Default;
        }
    }
    public class Item
    {
        private string _name;
        private string _factory;
        private float _num;
        private List<Formula>? formulas = new();
        public string Name { get => _name; set => _name = value; }
        public string Factory { get => _factory; set => _factory = value; }
        public float Num { get => _num; set => _num = value; }
        internal List<Formula>? Formulas { get => formulas; set => formulas = value; }

        public Item(string name, string factory, List<Formula> dic, int num)
        {
            this.Name = name;
            this.Factory = factory;
            this.Formulas = dic;
            this.Num = num;
        }
        public Item() { }

    }

    public class Formula
    {

        private Item _item;
        private float _num;

        public Item Item { get => _item; set => _item = value; }
        public float Num { get => _num; set => _num = value; }
        public Formula() { }
        public Formula(Item item, float num)
        {
            Item = item;
            Num = num;
        }
    }
    public class Factory
    {

        private string _itemName;
        private float _itemNum;
        private string _factoryName;
        private float _factoryNum;



        public Factory() { }

        public Factory(string itemName, float itemNum, string factoryName, float factoryNum)
        {
            ItemName = itemName;
            ItemNum = itemNum;
            FactoryName = factoryName;
            FactoryNum = factoryNum;
        }
        public override string ToString()
        {
            return "[" + _itemName + ":" + _itemNum + "," + _factoryName + ":" + _factoryNum + "]";
        }

        public string ItemName { get => _itemName; set => _itemName = value; }
        public float ItemNum { get => _itemNum; set => _itemNum = value; }
        public string FactoryName { get => _factoryName; set => _factoryName = value; }
        public float FactoryNum { get => _factoryNum; set => _factoryNum = value; }
    }
    //public class FormulaTree<T>
    //{
    //    public FormulaTree()
    //    {
    //        nodes = new List<FormulaTree<T>>();
    //    }

    //    public FormulaTree(T data)
    //    {
    //        this.Data = data;
    //        nodes = new List<FormulaTree<T>>();
    //    }

    //    private FormulaTree<T> parent;
    //    /// <summary>
    //    /// 父结点
    //    /// </summary>
    //    public FormulaTree<T> Parent
    //    {
    //        get { return parent; }
    //    }
    //    /// <summary>
    //    /// 结点数据
    //    /// </summary>
    //    public T Data { get; set; }

    //    private List<FormulaTree<T>> nodes;
    //    /// <summary>
    //    /// 子结点
    //    /// </summary>
    //    public List<FormulaTree<T>> Nodes
    //    {
    //        get { return nodes; }
    //    }
    //    /// <summary>
    //    /// 添加结点
    //    /// </summary>
    //    /// <param name="node">结点</param>
    //    public void AddNode(FormulaTree<T> node)
    //    {
    //        if (!nodes.Contains(node))
    //        {
    //            node.parent = this;
    //            nodes.Add(node);
    //        }
    //    }
    //    /// <summary>
    //    /// 添加结点
    //    /// </summary>
    //    /// <param name="nodes">结点集合</param>
    //    public void AddNode(List<FormulaTree<T>> nodes)
    //    {
    //        foreach (var node in nodes)
    //        {
    //            if (!nodes.Contains(node))
    //            {
    //                node.parent = this;
    //                nodes.Add(node);
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// 移除结点
    //    /// </summary>
    //    /// <param name="node"></param>
    //    public void Remove(FormulaTree<T> node)
    //    {
    //        if (nodes.Contains(node))
    //            nodes.Remove(node);
    //    }
    //    /// <summary>
    //    /// 清空结点集合
    //    /// </summary>
    //    public void RemoveAll()
    //    {
    //        nodes.Clear();
    //    }
    //}

    //public static class Extensions
    //{
    //    public static string GetString<K, V>(this IDictionary<K, V> dict)
    //    {
    //        var items = dict.Select(kvp => kvp.ToString());
    //        return "{" + string.Join(", ", items) + "}";
    //    }
    //}

}
