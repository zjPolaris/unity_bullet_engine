一个基于 Unity2D开发的弹幕基础框架，实现了对象池管理、子弹运动逻辑和可配置的子弹发射器。

核心功能：
对象池系统 (projectilepool.cs)：使用 Unity 的 ObjectPool API 管理子弹的创建、回收和复用，有效减少运行时的性能开销。
可配置子弹对象 (projectileobject.cs)：通过 ScriptableObject 创建子弹数据配置，支持速度、加速度、角速度、生命周期等参数的随机范围设置，方便快速生成不同效果的子弹。
子弹运动逻辑 (projectiles.cs)：每帧更新子弹的线速度、角速度、位置和旋转，并在生命周期结束后自动回收到对象池。
单例模式基类 (singleton.cs)：提供了一个简单的单例基类，便于管理全局对象。

文件结构：

├── projectiles.cs          # 子弹行为脚本
├── projectilepool.cs       # 对象池管理脚本
├── projectileobject.cs     # 子弹数据配置 
├── Sender.cs               # 子弹发射器逻辑
├── poolmanager.cs          # 全局对象池管理器
└── singleton.cs            # 单例模式基类
使用示例
将这些脚本导入编辑器。
在编辑器中，右键点击 Create->create projectile，即可创建一个默认值的子弹数据配置预制体。
在配置中调整子弹的各项参数。
将配置对象赋值给Sender脚本，或者直接通过代码创建，即可在指定位置生成子弹。
