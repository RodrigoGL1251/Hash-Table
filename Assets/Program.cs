using System.Collections;
using TMPro;
using UnityEngine;

public class Program : MonoBehaviour
{
    Hashtable m_usersTable = new Hashtable();

    //Save input fields
    [Header("Save")]
    public TMP_InputField m_id;
    public TMP_InputField m_email;
    public TMP_InputField m_password;
    [Header("Login")]
    //Load input fields
    public TMP_InputField m_logEmail;
    public TMP_InputField m_logPassword;

    [Header("Load")]
    //Data texts
    public TMP_Text m_emailText;
    public TMP_Text m_idText;


    public void SaveData()
    {
        if(m_email.text == "" || m_email.text == "" || m_password.text == "")
        {
            Debug.Log("Tienes que llenar todos los campos");
            return;
        }

        UserData newUser = new UserData(m_email.text, m_id.text, m_password.text);
        m_usersTable.Add(m_email.text, newUser);

        m_email.text = "";
        m_id.text = "";
        m_password.text = "";

        Debug.Log("save user");
    }

    public void Load()
    {
        UserData temp = (UserData)m_usersTable[m_logEmail.text];

        if(temp == null)
        {
            Debug.Log("invalid email");
            m_emailText.text = "--";
            m_idText.text = "--";
            return;
        }

        if(temp.Password != m_logPassword.text)
        {
            Debug.Log("invalid password");
            m_emailText.text = "--";
            m_idText.text = "--";
            return;
        }

        m_emailText.text = temp.Email;
        m_idText.text = temp.Id;
    }
}
