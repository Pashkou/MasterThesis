using System;
using System.Reflection;
/*
 * This code is copied from the Haibo Luo's weblog - System.Reflection-based ILReader
 * http://blogs.msdn.com/b/haibo_luo/archive/2006/11/06/system-reflection-based-ilreader.aspx
 * */
namespace ClrTest.Reflection {
    public interface IILProvider {
        Byte[] GetByteArray();
    }

    public class MethodBaseILProvider : IILProvider {
        MethodBase m_method;
        byte[] m_byteArray;

        public MethodBaseILProvider(MethodBase method) {
            m_method = method;
        }

        public byte[] GetByteArray() {
            if (m_byteArray == null) {
                MethodBody methodBody = m_method.GetMethodBody();
                m_byteArray = (methodBody == null) ? new Byte[0] : methodBody.GetILAsByteArray();
            }
            return m_byteArray;
        }
    }
}
