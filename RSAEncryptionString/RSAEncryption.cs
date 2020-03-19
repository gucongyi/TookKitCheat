using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public static class RSAEncryption 
{
    //加密和解密采用相同的key,可以任意数字，但是必须为32位
    private static string key = "zfgdesruj754cfdertgf4dzr67bgfd47";

    public static string Encrypt(string content)
    {
        return Encrypt(content, key);
    }

    //加密
    private static string Encrypt(string content, string k)
    {
        byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(k);
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = keyBytes;
        rm.Mode = CipherMode.ECB;
        rm.Padding = PaddingMode.PKCS7;
        ICryptoTransform ict = rm.CreateEncryptor();
        byte[] contentBytes = UTF8Encoding.UTF8.GetBytes(content);
        byte[] resultBytes = ict.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
        return Convert.ToBase64String(resultBytes, 0, resultBytes.Length);
    }

    public static string Decipher(string content)
    {
        return Decipher(content, key);
    }

    //解密
    private static string Decipher(string content, string k)
    {
        byte[] keyBytes = UTF8Encoding.UTF8.GetBytes(k);
        RijndaelManaged rm = new RijndaelManaged();
        rm.Key = keyBytes;
        rm.Mode = CipherMode.ECB;
        rm.Padding = PaddingMode.PKCS7;
        ICryptoTransform ict = rm.CreateDecryptor();
        byte[] contentBytes = Convert.FromBase64String(content);
        byte[] resultBytes = ict.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
        return UTF8Encoding.UTF8.GetString(resultBytes);
    }
}
