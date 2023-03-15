using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{

    /// <summary>
    /// Компиляция шейдеров.
    /// </summary>
    public static class Shaders
    {

        /// <summary>
        /// Инициализация компиляции шейдеров.
        /// </summary>
        /// <param name="type"> Тип шейдера. </param>
        /// <param name="path"> Путь к шейдеру. </param>
        public static int CompileShader(ShaderType type, string path)
        {
            var shader = GL.CreateShader(type);
            var scr = File.ReadAllText(path);
            GL.ShaderSource(shader, scr);
            GL.CompileShader(shader);
            var info = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrEmpty(info))
            {
                Debug.WriteLine($"GL.CompileShader [{type}] had info log {info}");
            }
            return shader;
        }
    }


}
