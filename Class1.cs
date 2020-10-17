using System;
using System.Threading;
using WindowsFormsApp1;
using System.Windows.Forms;

public class Class1
{
    Thread thread;

    public Class1(string name, int num)
    {
        thread = new Thread(this.func);
        thread.Name = name;
        thread.Start(num);

    }

    void func(object num)
    {
        send_to_form(Thread.CurrentThread.Name + " начался");
        for (int i = 0; i < (int)num; i++)
        {
            Thread.Sleep(1000);
            send_to_form(Thread.CurrentThread.Name + " выводит " + i);
        }
        send_to_form(Thread.CurrentThread.Name + " завершился сам");
    }

    void send_to_form(String text)
    {
        try
        {
            if (Program.main_form.InvokeRequired)
            {
                Program.main_form.BeginInvoke(new MethodInvoker(delegate
                {
                    Program.main_form.set_text(text);
                }));
            }
            else
            {
                Program.main_form.set_text(text);
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void stop()
    {
        if (thread.IsAlive) { 
            send_to_form(thread.Name + " завершился пользователем");
            thread.Abort();
        }
    }
}