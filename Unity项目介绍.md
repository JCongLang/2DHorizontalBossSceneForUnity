# inputSystem

1. ![1718282736366](F:\Typora\imgTemp\1718282736366.jpg)

2. 安装

   window->Package Manager->...->install

3. 创建配置文件

   <img src="F:\Typora\imgTemp\1718283393437.png" alt="1718283393437" style="zoom: 80%;" />



<img src="F:\Typora\imgTemp\1718283433736.png" alt="1718283433736" style="zoom: 50%;" />

<img src="F:\Typora\imgTemp\1718283508442.png" alt="1718283508442" style="zoom: 80%;" />

4. 双击配置文件打开：

<img src="F:\Typora\imgTemp\1718283695690.png" alt="1718283695690" style="zoom:80%;" />

<img src="F:\Typora\imgTemp\1718283779100.png" alt="1718283779100"  />

![1718283984676](F:\Typora\imgTemp\1718283984676.png)

5. 配置手柄：

   ![image-20240613210751797](F:\Typora\imgTemp\image-20240613210751797.png)

![image-20240613210831637](F:\Typora\imgTemp\image-20240613210831637.png)

6. 添加配置表配置什么时候用哪种输入设备：

   ![image-20240613211059160](F:\Typora\imgTemp\image-20240613211059160.png)

   键盘：

![image-20240613211152276](F:\Typora\imgTemp\image-20240613211152276.png)

手柄：

![image-20240613211235643](F:\Typora\imgTemp\image-20240613211235643.png)

![image-20240613211310513](F:\Typora\imgTemp\image-20240613211310513.png)

## 自动生成

![image-20240613211450546](F:\Typora\imgTemp\image-20240613211450546.png)

<img src="F:\Typora\imgTemp\image-20240613211557243.png" alt="image-20240613211557243" style="zoom:150%;" />

## 代码方式

![image-20240613211951721](F:\Typora\imgTemp\image-20240613211951721.png)

# 移动转向

1. transform.eulerAngles = new Vector3(0, faceDir > 0 ? 0 : 180, 0);
2. 

# 跳跃

1.InputSystem按键设置

2.竖直方向上，施加力`rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);`

3.♥♥♥触地条件检测ConditionalCheck->限制跳跃次数

指定位置的重叠碰撞检测：

`Physics2D.OverlapCircle(circleCenter, circleRadius, layerMask);//中心点、检测半径、碰撞体所在的层。`

4.绘制

```
private void OnDrawGizmosSelected()//绘制physicscheck的检测范围
{
    Gizmos.DrawWireSphere(circleCenter, circleRadius);//中心点、检测半径
}
```

# 状态机

## 搭建

![image-20240618150817944](F:\Typora\imgTemp\image-20240618150817944.png)

1.创建基础状态类IState（接口类型）

![image-20240618143713701](F:\Typora\imgTemp\image-20240618143713701.png)

------

2.创建状态机类本身StateMachine

功能：①持有所有状态类并对他们进行管理和切换②负责当前状态类的更新

![image-20240618144531894](F:\Typora\imgTemp\image-20240618144531894.png)

------

3.针对玩家，创建①玩家状态机类PlayerStateMachine：继承自StateMachine

![image-20240618150657012](F:\Typora\imgTemp\image-20240618150657012.png)

②玩家状态类PlayerState：继承IState接口和ScriptableObject

设计虚函数方便子类重写virtual

![image-20240618150542712](F:\Typora\imgTemp\image-20240618150542712.png)

## 状态切换

![image-20240618163816219](F:\Typora\imgTemp\image-20240618163816219.png)

### 常规写法（完全使用代码控制Animation）

1. 创建AnimatiorController，将Animation->AnimatiorController

2. 条件检测：A或D键被按下

   ```
   Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed
   ```

3. 播放动画：

   ```
   _animator.Play("Player_Walk");
   ```

![image-20240618192126452](F:\Typora\imgTemp\image-20240618192126452.png)

------

### 状态机写法

1.PlayerStateMachine脚本挂载

2.创建具体状态脚本-PlayerState_Idle   PlayerState_Run-继承自PlayState。PlayState继承自ScriptableObject，故

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]

![image-20240618194533487](F:\Typora\imgTemp\image-20240618194533487.png)

3.创建资产文件至Data目录

4.实现状态机脚本

![image-20240618193641503](F:\Typora\imgTemp\image-20240618193641503.png)

5.实现具体状态PlayerState_Idle   PlayerState_Run脚本逻辑

![image-20240618193929408](F:\Typora\imgTemp\image-20240618193929408.png)

### 两种方法对比

![image-20240618202804013](F:\Typora\imgTemp\image-20240618202804013.png)

### 状态机写法优化

PlayerStateMachine玩家状态机脚本中，如果为每一个状态都声明初始化，则过于繁琐。

解决

1.序列化+集合  ->声明

![image-20240618203255786](F:\Typora\imgTemp\image-20240618203255786.png)

2.循环初始化

![image-20240618203320760](F:\Typora\imgTemp\image-20240618203320760.png)

3.用字典获取每一个状态。->在状态机脚本中

![image-20240618204218519](F:\Typora\imgTemp\image-20240618204218519.png)

4.玩家状态机类中字典初始化。->玩家状态机脚本中

![image-20240618204452952](F:\Typora\imgTemp\image-20240618204452952.png)

5.重写状态机类中的SwitchOn和SwitchState

![image-20240618204837078](F:\Typora\imgTemp\image-20240618204837078.png)

6.状态切换->

![image-20240618204936998](F:\Typora\imgTemp\image-20240618204936998.png)

# InputSystem续上

1.创建InputAction，创建GamePlay动作表，绑定按键

同步手柄与键盘->Digital

2.生成C#脚本

3.创建玩家输入类PlayerInput

初始化

启用GamePlay动作表->Enable()

光标设为锁定模式

![image-20240619202602094](F:\Typora\imgTemp\image-20240619202602094.png)

4.挂载到Player上

5.玩家控制类PlayerController中，

![image-20240619202810789](F:\Typora\imgTemp\image-20240619202810789.png)

6.返回玩家输入类PlayerInput，获取输入反馈

![image-20240619203145579](F:\Typora\imgTemp\image-20240619203145579.png)

7.应用到状态机。在PlayerState类中

![image-20240619203350705](F:\Typora\imgTemp\image-20240619203350705.png)

8.在玩家状态机类PlayerStateMachine类中

![image-20240619203523447](F:\Typora\imgTemp\image-20240619203523447.png)

9.在玩家移动状态类PlayerState_Idle中

![image-20240619203701168](F:\Typora\imgTemp\image-20240619203701168.png)

# 玩家移动

1.挂载Rigidbody组件

2.在玩家控制类PlayerController中：声明、实例化、创建修改刚体速度的函数

![image-20240620154620774](F:\Typora\imgTemp\image-20240620154620774.png)

![image-20240620154703156](F:\Typora\imgTemp\image-20240620154703156.png)

3.在玩家状态类PlayerState中，

![image-20240620154852160](F:\Typora\imgTemp\image-20240620154852160.png)

4.在状态机类中取得玩家控制器PlayerController脚本

![image-20240620155105594](F:\Typora\imgTemp\image-20240620155105594.png)

5.在具体玩家状态类中实现：

![image-20240620155259885](F:\Typora\imgTemp\image-20240620155259885.png)

## 左右移动

1.玩家控制类PlayerController中：

![image-20240620155656608](F:\Typora\imgTemp\image-20240620155656608.png)

具体状态类：

![image-20240620155723372](F:\Typora\imgTemp\image-20240620155723372.png)

## 移动朝向

两种方法：①选择Y轴Rotation②镜像翻转Mirror Flipping

区别：①选择Y轴Rotation：左手是左手，右手是右手

②镜像翻转Mirror Flipping：左手是右手，右手是左手![image-20240620161935902](F:\Typora\imgTemp\image-20240620161935902.png)

![image-20240620161959862](F:\Typora\imgTemp\image-20240620161959862.png)

视觉习惯上更倾向于选择：②镜像翻转Mirror Flipping：

![image-20240620162201867](F:\Typora\imgTemp\image-20240620162201867.png)

## 切换到空闲状态时立即停止

在空闲状态进入时：

![image-20240620162434740](F:\Typora\imgTemp\image-20240620162434740.png)

## 优化-移动中的加速与减速

![image-20240622172033959](F:\Typora\imgTemp\image-20240622172033959.png)

1.在PlayerController中声明移动速度，并赋值刚体velocity.x的绝对值

![image-20240622172236875](F:\Typora\imgTemp\image-20240622172236875.png)

2.在玩家状态PlayerState中声明当前速度

![image-20240622172354854](F:\Typora\imgTemp\image-20240622172354854.png)

3.在跑步状态PlayerState_Run中

进入状态时：当前速度<=Player.移动速度

逻辑更新：**Mathf.MoveTowards**(float **current**, float **target**, float **maxDelta**) : 将值 `current` 向 `target` 靠近；maxDelta为加速度。

![image-20240622191716826](F:\Typora\imgTemp\image-20240622191716826.png)

**减速过程**：在玩家空闲状态：PlayerState_Idle中：

1.进入空闲状态时，记录当前玩家速度

2.在逻辑更新函数中逐帧修改当前速度，并声明减速度deceleration

3.进行逻辑更新，此时减速是没有玩家输入的，因此乘上当前玩家面朝方向

![image-20240622192527211](F:\Typora\imgTemp\image-20240622192527211.png)

![image-20240622192631428](F:\Typora\imgTemp\image-20240622192631428.png)

# 相机跟随

1.导入cinemachine插件，=>①相机跟随②状态驱动相机

2.Hierarchy窗口右键Cinemachine创建virtualCamera

![image-20240622200633512](F:\Typora\imgTemp\image-20240622200633512.png)

3.将被跟随对象拖拽到Follow

![image-20240622200830720](F:\Typora\imgTemp\image-20240622200830720.png)

4.Aim=>Donothing

Body=>Framing Transposer

![image-20240622201232870](F:\Typora\imgTemp\image-20240622201232870.png)

## 添加相机边界

1.CinemachinePixelPerfect=>避免像素扭曲

2.CinemachineConfiner2D=>限定区域

![image-20240622202513844](F:\Typora\imgTemp\image-20240622202513844.png)

3.创建一个新的Object，添加Polygan colider 2D， 勾选isTrigger

![image-20240622202725156](F:\Typora\imgTemp\image-20240622202725156.png)

4.拖拽Object至BoundingShape2D

## 切换场景后新的Bounds获取

https://www.bilibili.com/video/BV1i94y1W75i?t=388.8

1.为Object-Bounds添加标签

![image-20240622203336984](F:\Typora\imgTemp\image-20240622203336984.png)

2.创建CameraControl脚本挂载至VirtalCamera

![image-20240622203735523](F:\Typora\imgTemp\image-20240622203735523.png)

3.缓存清除

![image-20240622203906626](F:\Typora\imgTemp\image-20240622203906626.png)

4.游戏开始时获取边界

![image-20240622204011647](F:\Typora\imgTemp\image-20240622204011647.png)

# 动画播放优化

Animator.Play() => Animator.CrossFade（动画名称或对应的哈希值，过渡时间）淡入淡出流畅的动画切换

 Animatior.StringToHash=》动画名称->哈希值

1.切换状态的第一件事=》播放动画，因此在

①PlayerState基类的Enter()中播放动画Animator.CrossFade

②声明一个序列化的字符串变量存储每个状态的动画状态名称

③声明一个整形变量存储转换后的哈希值

④在Onenable函数中进行哈希值转换

⑤声明一个序列化的浮点型存储动画过渡事件

⑤传入CrossFade

⑥在具体状态类中，就不再需要Animator.Play()，只需要调用基类的enter()函数

⑦只需要再编辑器的资产文件中输入-》动画名称

![image-20240624160105786](F:\Typora\imgTemp\image-20240624160105786.png)

![image-20240624160235593](F:\Typora\imgTemp\image-20240624160235593.png)

![image-20240624160541588](F:\Typora\imgTemp\image-20240624160541588.png)

![image-20240624160714397](F:\Typora\imgTemp\image-20240624160714397.png)


# 跳跃状态分析

①三种状态：PlayerState_JumpUp   PlayerState_Fall   PlayerState_Land     

②创建对应脚本

![image-20240624163103284](F:\Typora\imgTemp\image-20240624163103284.png)

## 地面检测Physics.overlap（）

③对Player新建一个子对象GroundDetector并新建脚本PlayerGroundDetector

![image-20240624164327720](F:\Typora\imgTemp\image-20240624164327720.png)

④创建共有属性isGround

![image-20240624164534934](F:\Typora\imgTemp\image-20240624164534934.png)

![image-20240624164932157](F:\Typora\imgTemp\image-20240624164932157.png)

⑤在别的类中调用，声明一个PlayerGoundDetector并在Awake中获取实例。声明一个bool类型isGound获取PlayerGoundDetector.isGround

⑥判断是否是掉落状态

![image-20240624170442571](F:\Typora\imgTemp\image-20240624170442571.png)

## 检测当前动画是否播放完成

在PlayerState中

![image-20240624190939032](F:\Typora\imgTemp\image-20240624190939032.png)

![image-20240624191052668](F:\Typora\imgTemp\image-20240624191052668.png)

## 跳起状态PlayerState_JumpUp

### 状态切换

①落地状态-》跳起状态

![image-20240625001352628](F:\Typora\imgTemp\image-20240625001352628.png)

②跑步状态-》跳起状态

![image-20240625001512848](F:\Typora\imgTemp\image-20240625001512848.png)

③空闲状态-》跳起状态

![image-20240625001549990](F:\Typora\imgTemp\image-20240625001549990.png)

④跳起状态-》掉落状态（玩家下落时）

![image-20240625001803962](F:\Typora\imgTemp\image-20240625001803962.png)

### 动画和物理更新

⑤动画

![image-20240625002011228](F:\Typora\imgTemp\image-20240625002011228.png)

⑥物理逻辑

![image-20240625002128031](F:\Typora\imgTemp\image-20240625002128031.png)

## 掉落状态PlayerState_Fall

### 状态切换

①跑步状态-》掉落状态

![image-20240625004308640](F:\Typora\imgTemp\image-20240625004308640.png)

②空闲状态-》掉落状态

![image-20240625004405927](F:\Typora\imgTemp\image-20240625004405927.png)

③跳起状态-》掉落状态（已实现）

④掉落状态-》落地状态

![image-20240625004626317](F:\Typora\imgTemp\image-20240625004626317.png)

### 物理更新

对掉落速度的控制，而不是对重力的模拟--》AnimationCurve动画曲线

①创建序列化AnimationCurve变量

![image-20240625004840179](F:\Typora\imgTemp\image-20240625004840179.png)

②创建玩家掉落状态的可程序化对象文件

![image-20240625004956213](F:\Typora\imgTemp\image-20240625004956213.png)

![image-20240625005055245](F:\Typora\imgTemp\image-20240625005055245.png)

③起点设为（0，0）；第二个点设为（0.5，-15）

![image-20240625005205466](F:\Typora\imgTemp\image-20240625005205466.png)

④两个点都选择Flat

![image-20240625005342486](F:\Typora\imgTemp\image-20240625005342486.png)

⑤物理更新

![image-20240625005514891](F:\Typora\imgTemp\image-20240625005514891.png)

## 落地状态 PlayerState_Land

### 状态切换

①落地状态-》跳起状态（以实现）

②落地状态-》跑步状态

![image-20240625005754876](F:\Typora\imgTemp\image-20240625005754876.png)

③落地状态-》空闲状态

![image-20240625005837112](F:\Typora\imgTemp\image-20240625005837112.png)

④进入落地状态时，速度归零

![image-20240625005954838](F:\Typora\imgTemp\image-20240625005954838.png)

⑤创建玩家跳起状态和玩家落地状态 两个可程序化对象文件

![image-20240625010118379](F:\Typora\imgTemp\image-20240625010118379.png)

⑥设置动画名称字符串

![image-20240625010201697](F:\Typora\imgTemp\image-20240625010201697.png)

⑦拖拽至玩家状态机脚本

![image-20240625010243183](F:\Typora\imgTemp\image-20240625010243183.png)

⑧底边检测器的LayerMask-》Ground

![image-20240625010338594](F:\Typora\imgTemp\image-20240625010338594.png)

## 跳跃时移动

①进行物理更新

![image-20240625010649359](F:\Typora\imgTemp\image-20240625010649359.png)

![image-20240625010752662](F:\Typora\imgTemp\image-20240625010752662.png)

## 解决跳到墙壁不动的情况

![image-20240625182503627](F:\Typora\imgTemp\image-20240625182503627.png)

两种解决方法：

①投射球体。适合有特殊需求的项目中。例如爬墙

![image-20240625182703781](F:\Typora\imgTemp\image-20240625182703781.png)

![image-20240625182728613](F:\Typora\imgTemp\image-20240625182728613.png)

②给墙壁添加没有摩檫力的材质

![image-20240625183351852](F:\Typora\imgTemp\image-20240625183351852.png)

![image-20240625183528076](F:\Typora\imgTemp\image-20240625183528076.png)

![image-20240625183733318](F:\Typora\imgTemp\image-20240625183733318.png)

## 小跳--根据玩家按跳跃键事件决定跳跃高度

![image-20240625185552610](F:\Typora\imgTemp\image-20240625185552610.png)

![image-20240625185701693](F:\Typora\imgTemp\image-20240625185701693.png)

## 落地状态硬直

①在落地状态声明浮点型变量

②若当前动画的持续时间小于硬直时间，返回不执行下面代码

![image-20240625190244382](F:\Typora\imgTemp\image-20240625190244382.png)

# 二段跳

①在跳跃状态 松开跳跃键-》Fall掉落状态 再次按下跳跃 -》二次跳跃状态

![image-20240625192534774](F:\Typora\imgTemp\image-20240625192534774.png)

②创建二次跳跃状态

![image-20240625192743222](F:\Typora\imgTemp\image-20240625192743222.png)

③代码和JumpUp状态相同

![image-20240625192857070](F:\Typora\imgTemp\image-20240625192857070.png)

④空中跳跃状态的功能限制：只有空中跳跃能力开启时才能二次跳跃

![image-20240625193108105](F:\Typora\imgTemp\image-20240625193108105.png)

⑤在进入AirJump时关闭CanAirJump-》限制玩家连续跳跃

![image-20240625193258941](F:\Typora\imgTemp\image-20240625193258941.png)

⑥在进入落地状态时，再次将CanAirJump开启

![image-20240625193410410](F:\Typora\imgTemp\image-20240625193410410.png)

⑦在掉落状态时，如果按下跳跃键并且二次跳跃功能开启时，进入二次跳跃状态

![image-20240625193451991](F:\Typora\imgTemp\image-20240625193451991.png)

⑧创建可程序化脚本文件并拖拽至玩家状态机。略

⑨添加二次跳跃动画

# Behavior Designer -- Boss

![image-20240701191330499](F:\Typora\imgTemp\image-20240701191330499.png)

## DOtween插件

## Jump

①创建敌人行为节点和条件节点作为父类

![image-20240629214220844](F:\Typora\imgTemp\image-20240629214220844.png)

![image-20240701145020974](F:\Typora\imgTemp\image-20240701145020974.png)

改-》由于playercontroller并不挂载在Boss上，所以getComponent并不能实例化->改为实例模式：

![image-20240701154524572](F:\Typora\imgTemp\image-20240701154524572.png)

![image-20240701154603263](F:\Typora\imgTemp\image-20240701154603263.png)

②创建具体行为-Jump继承自->EnemyAction

![image-20240701153849655](F:\Typora\imgTemp\image-20240701153849655.png)

![image-20240701153940411](F:\Typora\imgTemp\image-20240701153940411.png)

![image-20240701154014308](F:\Typora\imgTemp\image-20240701154014308.png)

③

![image-20240701191922747](F:\Typora\imgTemp\image-20240701191922747.png)

## 朝向FaceDir

①

![image-20240701192827988](F:\Typora\imgTemp\image-20240701192827988.png)

②

![image-20240701192854857](F:\Typora\imgTemp\image-20240701192854857.png)

### shared版

![image-20240702145102715](F:\Typora\imgTemp\image-20240702145102715.png)

![image-20240702145127516](F:\Typora\imgTemp\image-20240702145127516.png)

![image-20240702145210322](F:\Typora\imgTemp\image-20240702145210322.png)

![image-20240702145227949](F:\Typora\imgTemp\image-20240702145227949.png)

## Player与Boss的碰撞问题

设置不同的Layer

## Boss技能

### Shoot类型的攻击-ShootAttack

![image-20240705212057309](F:\Typora\imgTemp\image-20240705212057309.png)

#### 准备工作

①设置基类Abstractprojectile

![image-20240702152439212](F:\Typora\imgTemp\image-20240702152439212.png)

![image-20240702152535928](F:\Typora\imgTemp\image-20240702152535928.png)

②Weapon类（叫做**BossSkill**类更合理）

![image-20240702153458984](F:\Typora\imgTemp\image-20240702153458984.png)

③控制远程攻击距离速度-AcceleratingProjectile

![image-20240702153644730](F:\Typora\imgTemp\image-20240702153644730.png)

![image-20240702153730023](F:\Typora\imgTemp\image-20240702153730023.png)

#### ACTION脚本

①创建脚本

![image-20240702191159053](F:\Typora\imgTemp\image-20240702191159053.png)

②

![image-20240702192010752](F:\Typora\imgTemp\image-20240702192010752.png)

![image-20240702192040592](F:\Typora\imgTemp\image-20240702192040592.png)

#### 组件设置

①设置碰撞体

![image-20240703145608828](F:\Typora\imgTemp\image-20240703145608828.png)

②挂载脚本--AccelerateingProjectile

![image-20240703145725028](F:\Typora\imgTemp\image-20240703145725028.png)

### 环境类型的攻击--FireBallFallAttack

![image-20240705212551062](F:\Typora\imgTemp\image-20240705212551062.png)

#### 火球设置

①碰撞体设置

![image-20240703150104785](F:\Typora\imgTemp\image-20240703150104785.png)

②脚本创建

![image-20240703150226002](F:\Typora\imgTemp\image-20240703150226002.png)

③脚本设置

![image-20240703150453665](F:\Typora\imgTemp\image-20240703150453665.png)

④挂载组件

![image-20240703150636224](F:\Typora\imgTemp\image-20240703150636224.png)

![image-20240703150701327](F:\Typora\imgTemp\image-20240703150701327.png)

⑤将两个Weapon设置为预制体-》直接拖拽至文件夹即可

![image-20240703150910149](F:\Typora\imgTemp\image-20240703150910149.png)

#### 随机设置火球掉落

①创建一个GameObject设置区域、

②添加碰撞体设置掉落区域-》isTrigger-》Layer

![image-20240703151520553](F:\Typora\imgTemp\image-20240703151520553.png)

③随机火球掉落的脚本设置

![image-20240703152017205](F:\Typora\imgTemp\image-20240703152017205.png)

④自定义的ACTION编写， Quaternion.identity

![image-20240703234344829](F:\Typora\imgTemp\image-20240703234344829.png)

### 技能组合--Boss做出攻击动画后释放ShootAttack+FireBallFallAttack

①制作攻击动画

②行为树设置

![image-20240705213229913](F:\Typora\imgTemp\image-20240705213229913.png)



③ShootAction参数设置

![image-20240705213933050](F:\Typora\imgTemp\image-20240705213933050.png)

④在Boss下添加WeaponTransform以及拖拽至参数

![image-20240705214145936](F:\Typora\imgTemp\image-20240705214145936.png)

⑤FireBallFall参数设置

![image-20240705214325548](F:\Typora\imgTemp\image-20240705214325548.png)

⑥

![image-20240705214404846](F:\Typora\imgTemp\image-20240705214404846.png)



### Boss本身造成的伤害技能

挥锤砸下**那一帧时**，锤子会有一个伤害

![image-20240706214706008](F:\Typora\imgTemp\image-20240706214706008.png)

①BossgameObject下创建子物体AttackCollider，并添加碰撞体组件，默认取消勾选

![image-20240706215007291](F:\Typora\imgTemp\image-20240706215007291.png)

②添加新的事件AttackAnimatorEvent

![image-20240706215218913](F:\Typora\imgTemp\image-20240706215218913.png)

![image-20240706215413253](F:\Typora\imgTemp\image-20240706215413253.png)

③AttackAnimatorEvent添加至Boss，给AttackCollider拖拽AttackCollider赋值

![image-20240706215505551](F:\Typora\imgTemp\image-20240706215505551.png)

④对Animator的特定帧事件进行赋值

![image-20240706215734015](F:\Typora\imgTemp\image-20240706215734015.png)

![image-20240706215637877](F:\Typora\imgTemp\image-20240706215637877.png)

⑤碰撞体赋值

![image-20240708230500370](F:\Typora\imgTemp\image-20240708230500370.png)

⑥触发伤害脚本Hazard

![image-20240714232241519](F:\Typora\imgTemp\image-20240714232241519.png)

⑦脚本Hazard挂载至AttackCollider

![image-20240714232337741](F:\Typora\imgTemp\image-20240714232337741.png)

### 技能组合RomdomSelector

![image-20240708232508050](F:\Typora\imgTemp\image-20240708232508050.png)

## 条件节点--Conditional--判断BOSS是否到阈值以切换状态

①EnemyConditional

![image-20240709224624609](F:\Typora\imgTemp\image-20240709224624609.png)

②创建Conditional节点脚本

![image-20240709224721711](F:\Typora\imgTemp\image-20240709224721711.png)

![image-20240709224954800](F:\Typora\imgTemp\image-20240709224954800.png)

③行为树设计，参数设置

![image-20240709225151305](F:\Typora\imgTemp\image-20240709225151305.png)

④添加中断

![image-20240709225404322](F:\Typora\imgTemp\image-20240709225404322.png)

## 满足条件后进入某种状态（）

![image-20240709225828881](F:\Typora\imgTemp\image-20240709225828881.png)

①添加新的具体的行为节点

![image-20240709230115230](F:\Typora\imgTemp\image-20240709230115230.png)

![image-20240709230356423](F:\Typora\imgTemp\image-20240709230356423.png)

![image-20240709230757719](F:\Typora\imgTemp\image-20240709230757719.png)

②添加行为节点

![image-20240709230913090](F:\Typora\imgTemp\image-20240709230913090.png)

③虚弱后的复活，对生命值的重置，添加SetHealth行为节点脚本

![image-20240709231009924](F:\Typora\imgTemp\image-20240709231009924.png)

![image-20240709231235430](F:\Typora\imgTemp\image-20240709231235430.png)

④

![image-20240709231547979](F:\Typora\imgTemp\image-20240709231547979.png)

⑤实例化--创建新GameObject------Maggot

![image-20240709231814538](F:\Typora\imgTemp\image-20240709231814538.png)

⑥添加Animator

![image-20240709231901812](F:\Typora\imgTemp\image-20240709231901812.png)

⑦创建动画控制器并添加

![image-20240709232004550](F:\Typora\imgTemp\image-20240709232004550.png)

![image-20240709232047755](F:\Typora\imgTemp\image-20240709232047755.png)

⑧创建Animation

⑨对于Maggot-添加Enemy脚本

![image-20240709232255020](F:\Typora\imgTemp\image-20240709232255020.png)

⑩创建碰撞体、Hazard脚本

![image-20240709232358121](F:\Typora\imgTemp\image-20240709232358121.png)

![image-20240709232519894](F:\Typora\imgTemp\image-20240709232519894.png)

## 虚弱状态行为树设计

①将Maggot添加为预制体Prefobs

![image-20240709232730882](F:\Typora\imgTemp\image-20240709232730882.png)

②设定参数

![image-20240709232822820](F:\Typora\imgTemp\image-20240709232822820.png)

③对于MaggoTrans

![image-20240709235226687](F:\Typora\imgTemp\image-20240709235226687.png)

④

![image-20240709235320111](F:\Typora\imgTemp\image-20240709235320111.png)

⑤运行时的状态

![image-20240711205305886](F:\Typora\imgTemp\image-20240711205305886.png)

⑥死亡后的状态

## 跳跃攻击JumpAttack

①行为树设计

![image-20240715211328979](F:\Typora\imgTemp\image-20240715211328979.png)

②

![image-20240715211714647](F:\Typora\imgTemp\image-20240715211714647.png)

## 大招

![image-20240715211925491](F:\Typora\imgTemp\image-20240715211925491.png)

### 转身节点ACTION

![image-20240711210251578](F:\Typora\imgTemp\image-20240711210251578.png)

## 阶段设计--在不同阶段使用不同的攻击手段

①

![image-20240712003111297](F:\Typora\imgTemp\image-20240712003111297.png)

②行为节点脚本GoToNextStage

![image-20240712003306978](F:\Typora\imgTemp\image-20240712003306978.png)

![image-20240712003644902](F:\Typora\imgTemp\image-20240712003644902.png)

③

![image-20240712003722763](F:\Typora\imgTemp\image-20240712003722763.png)

## 自定义的复合节点

实现技能的选择（从5个技能组里选N个），源自RandomSelector

①

![image-20240712003951410](F:\Typora\imgTemp\image-20240712003951410.png)

②![image-20240712004357017](F:\Typora\imgTemp\image-20240712004357017.png)

③

![image-20240712004431891](F:\Typora\imgTemp\image-20240712004431891.png)

④![image-20240712004641910](F:\Typora\imgTemp\image-20240712004641910.png)

⑤RandomSelector替换为StageSelector

![image-20240712005017435](F:\Typora\imgTemp\image-20240712005017435.png)

## Boss的初始化和死亡

### 初始化

![image-20240712005226657](F:\Typora\imgTemp\image-20240712005226657.png)

### 死亡

![image-20240712005424384](F:\Typora\imgTemp\image-20240712005424384.png)

①Boss死亡节点

![image-20240712005539585](F:\Typora\imgTemp\image-20240712005539585.png)

②

![image-20240712005739328](F:\Typora\imgTemp\image-20240712005739328.png)

![image-20240712005816531](F:\Typora\imgTemp\image-20240712005816531.png)
