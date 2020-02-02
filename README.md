# -
winform版的小型货物管理系统，数据库使用了mysql，应用了代理模式，和抽象工厂模式的设计思想，可以快速搭建项目环境。
![image](https://github.com/377297468/-/blob/master/%E8%AE%BE%E8%AE%A1%E6%9E%84%E6%80%9D.png)

备注及还未改进的问题：

1.未对数据进行合法化判断，可能导致SQL注入,引起报错。

2.可选择不连续的多行进行删除，思路是将勾选中的行，存储到List中，然后遍历列表，逐个删除。缺点是当数据量较大时，处理时间可能变长。

3.当数据量很大时，需要进行分库分表处理。

4.MySqlDataReader打开后必须及时关闭，当需要多次打开时，需要先对上一个MySqlDataReader进行close()，否则报错。

5.MySqlDataAdapter 只能进行select操作。不能进行delete，insert，update操作。
