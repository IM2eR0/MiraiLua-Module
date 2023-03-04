using KeraLua;
using MiraiLua;
using TestModule1;

namespace TestModule1
{
    public class MiraiLuaModule
    {
        static object o = new object();
        static public Data Init()
        {
            o = ModuleFunctions.GetLock();//获取线程锁，防止异步操作崩Lua

            var data = new Data();
            data.WriteString("MiraiLua 示例模块"); //模块名称
            data.WriteString("1.0"); //模块版本
            data.WriteString("初雪 OriginalSnow"); //模块作者

            var lua = ModuleFunctions.GetLua();
            Util.PushFunction("_G", "test", lua, Test);

            return data;
        }

        static int Test(IntPtr p)
        {
            var lua = Lua.FromIntPtr(p); //从指针传入Lua函数

            lua.PushString("逸一时误一世");
            lua.PushBoolean(true);
            lua.PushNumber(114514);

            Util.Print("你好！", Util.PrintType.INFO);
            Util.Print("你好！", Util.PrintType.WARNING);
            Util.Print("你好！", Util.PrintType.ERROR);
            return 3;
        }
    }
}