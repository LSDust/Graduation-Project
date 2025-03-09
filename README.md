# Graduation Project

#### 介绍
25期毕设

#### 软件架构
Unity2022.3.53f1c1

#### C# 风格指南
1.使用大驼峰命名属性、方法、事件、枚举、类型和命名空间。
```
public class MyClass
{
    public event Action SomeEvent;
    public int Name { get; set; }
    
    [MenuItem("Window/SomeMenu")]
    public void DoSomething()
    {
    }
}
```
2.使用大驼峰命名静态变量，常量，和公开字段。<br>
3.使用小驼峰命名私有字段，临时变量，参数，无法被其他对象访问的私有字段应添加一个下划线前缀。<br>
4.布尔变量由小写介词短语开头，表示逻辑类型。
```
public static string AssetPath = "Asset/";
public const double Pi = 3.1415926;
public readonly int PhoneNumber = 123456;
public string Name = "Hanpi";

private int _health;

public bool isOnline;
[SerializeField] private bool canPlayGame;
```
5.类名应该是名词或者名词性短语。<br>
6.方法名应该是动宾/介宾短语。
```
public class GameManager
{
    public string GetName()
    {
        var tempVar = MakeName();
        return tempVar;
    }
}
```

#### 提交原则
1.所有的推送只推送到子分支<br>
2.远程主分支任何人无法推送<br>
3.只能用Pull Request把远程子分支的合并到远程主分支，以更新主分支<br>
4.拉取远程主分支以获取别人的更新<br>


#### 避免场景交叉修改导致的报错
1.只编辑自己文件夹下的场景<br>
2.完成编辑后，放到"Do Not Edit Scene"文件夹中<br>
3.需要修改"Do Not Edit Scene"中的场景时，剪切到自己的文件夹并马上更新一次远程主分支