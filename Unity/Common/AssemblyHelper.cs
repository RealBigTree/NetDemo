using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Common {
    /// <summary>
    /// 子类存在有构造函数时, 必须实现默认构造函数,如果没有则不会添加实例
    /// T不能为接口
    /// </summary>
    public static class AssemblyHelper {
        /// <summary>
        /// 根据目录获取T类型或者其子类(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseDirectory">目录</param>
        /// <returns>类型集合</returns>
        public static IEnumerable<Type> GetImplementdTypesByDirectory<T>(string baseDirectory) {
            IList<Assembly> assemblies = GetAssemblies(baseDirectory);
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in assemblies) {
                types.AddRange(GetImplementdTypes<T>(assembly));
            }

            return types;
        }

        /// <summary>
        /// 根据地址获取T类型或者其子类(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyFile">程序集文件</param>
        /// <returns>类型集合</returns>
        public static IEnumerable<Type> GetImplementdTypes<T>(string assemblyFile) {
            if (!File.Exists(assemblyFile)) {
                return null;
            }
            try {
                return GetImplementdTypes<T>(Assembly.LoadFile(assemblyFile));
            } catch (Exception ) {
                return null;
            }
        }

        /// <summary>
        /// 根据程序集获取T类型或者其子类(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">程序集</param>
        /// <returns>类型集合</returns>
        public static IEnumerable<Type> GetImplementdTypes<T>(Assembly assembly) {
            if (assembly == null) {
                return null;
            }

            return assembly.GetExportedTypes().Where(p => (p.GetInterfaces().Contains(typeof(T))
              || p.IsSubclassOf(typeof(T))) && (!p.IsAbstract) && (!p.IsInterface));
        }

        /// <summary>
        /// 根据目录动态获取程序集中T的特定对象集合(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseDirectory">目录</param>
        /// <returns>T对象集合</returns>
        public static IList<T> GetImplementedObjectsByDirectory<T>(string baseDirectory) {
            IList<Assembly> assemblies = GetAssemblies(baseDirectory);
            List<T> entities = new List<T>();
            foreach (Assembly assembly in assemblies) {
                entities.AddRange(GetImplementedObjects<T>(assembly));
            }

            return entities;
        }

        /// <summary>
        /// 根据地址动态获取程序集中T的特定对象集合(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyFile">地址</param>
        /// <returns>T对象集合</returns>
        public static IList<T> GetImplementedObjects<T>(string assemblyFile) {
            if (!File.Exists(assemblyFile)) {
                return null;
            }
            try {
                return GetImplementedObjects<T>(Assembly.LoadFile(assemblyFile));
            } catch (Exception ) {
                return null;
            }
        }

        /// <summary>
        /// 根据程序集动态获取程序集中T的特定对象集合(非抽象类和接口)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">程序集</param>
        /// <returns>T对象集合</returns>
        public static IList<T> GetImplementedObjects<T>(Assembly assembly) {
            if (assembly == null) {
                return null;
            }

            IEnumerable<Type> types = GetImplementdTypes<T>(assembly);
            var result = new List<T>();

            foreach (Type type in types) {
                ConstructorInfo constructor = type.GetConstructor(new Type[0]);
                if (constructor == null) {
                    continue;
                }

                object instance = Activator.CreateInstance(type);
                if (instance is T) {
                    result.Add((T)instance);
                }
            }

            return result;
        }

        public static IList<Assembly> GetAssemblies(string baseDirectory) {
            if (!Directory.Exists(baseDirectory)) {
                return new List<Assembly>();
            }

            string[] files = Directory.GetFiles(baseDirectory, "*.dll");

            return GetAssemblies(files);
        }

        public static IList<Assembly> GetAssemblies(string[] assemblyFiles) {
            IList<Assembly> assemblies = new List<Assembly>();
            try {
                foreach (string file in assemblyFiles) {
                    if (!File.Exists(file) || (!file.EndsWith(".dll", StringComparison.InvariantCultureIgnoreCase))) {
                        continue;
                    }
                    assemblies.Add(Assembly.LoadFile(file));
                }
            } catch (Exception ) {
                return new List<Assembly>();
            }

            return assemblies;
        }
    }
}
