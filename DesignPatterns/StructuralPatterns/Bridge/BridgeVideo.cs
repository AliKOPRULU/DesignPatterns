using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{//http://safakunel.blogspot.com/2013/10/c-bridge-pattern-kullanimi.html
    class BridgeVideo
    {
        public static void Main(string[] args)
        {
            VideoAbsraction video = new VideoAbsraction();
            video.VideoMode = new OpenGLMode();
            video.ShowScreen();

            Console.ReadKey();
        }
    }

    public interface IVideoMode
    {
        string GetScreen();
    }

    // ConcreteImplementor for OpenGL
    public class OpenGLMode : IVideoMode
    {
        const string MODE_NAME = "OpenGL Mode";
        public string GetScreen()
        {
            return string.Format("Video started with {0} ", MODE_NAME);
        }
    }

    // ConcreteImplementor for Direct3D
    public class Direct3DMode : IVideoMode
    {
        const string MODE_NAME = "Direct3D Mode";
        public string GetScreen()
        {
            return string.Format("Video started with {0}", MODE_NAME);
        }
    }

    public class VideoAbsraction
    {
        public IVideoMode _VideoMode;

        public IVideoMode VideoMode
        {
            set { _VideoMode = value; }
        }

        public virtual void ShowScreen()
        {
            Console.WriteLine(_VideoMode.GetScreen());
        }
    }

    public class VideoRefinedAbsraction : VideoAbsraction
    {
        public override void ShowScreen()
        {
            //base.ShowScreen();
            Console.WriteLine(_VideoMode.GetScreen());
        }
    }












}
