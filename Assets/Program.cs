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

    [Header("Load")]
    public GameObject panelMesage;
    public TMP_Text textMesage;
    public void SaveData()
    {
        if(m_email.text == "" || m_email.text == "" || m_password.text == "")
        {
            panelMesage.SetActive(true);
            textMesage.text = "Tienes que llenar todos los campos";
            return;
        }

        UserData newUser = new UserData(m_email.text, m_id.text, m_password.text);

        if((UserData)m_usersTable[m_email.text] != null)
        {
            panelMesage.SetActive(true);
            textMesage.text ="El usuario ya existe";
            return;
        }


        m_usersTable.Add(m_email.text, newUser);

        m_email.text = "";
        m_id.text = "";
        m_password.text = "";

        panelMesage.SetActive(true);
        textMesage.text = "Usuario creado con éxito";
    }

    public void Load()
    {
        UserData temp = (UserData)m_usersTable[m_logEmail.text];

        if(temp == null)
        {
            panelMesage.SetActive(true);
            textMesage.text = "Invalid email";
            m_emailText.text = "--";
            m_idText.text = "--";
            return;
        }

        if(temp.Password != m_logPassword.text)
        {
            panelMesage.SetActive(true);
            textMesage.text = "Invalid password";
            m_emailText.text = "--";
            m_idText.text = "--";
            return;
        }

        m_emailText.text = temp.Email;
        m_idText.text = temp.Id;
    }
}
