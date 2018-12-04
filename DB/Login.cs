using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public InputField nome;
	public InputField sobrenome;
	public InputField pass;
	public Text information;

	public string nome_t, sobrenome_t, pass_t; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sendLogin(){

		nome_t = nome.text;
		sobrenome_t = sobrenome.text;
		pass_t = pass.text;	

		StartCoroutine( login(nome_t, sobrenome_t, pass_t) );
		
	}

	IEnumerator login ( string nomeT, string sobrenomeT, string passT  ){
		Debug.Log("Cheguei");
		UnityWebRequest link = UnityWebRequest.Get("http://localhost/game/login.php?userName=" +nomeT+ "&userLastName=" +sobrenomeT+ "&userPass="+passT);
		yield return link.SendWebRequest();

		if(link.isNetworkError){
			Debug.Log(link.error);
		}else{
			string [] result = link.downloadHandler.text.ToString().Split(';');
			
			print(result);
			information.text = result[0].ToString();

			if(result[0].ToString() == "Autenticado"){
				//GlobalControl.Instance.id = int.Parse( result[1].ToString() );
				
				int pos = result[1].IndexOf(":")+1;
				string id = result[1].Substring(pos).Trim();
				print(id+" dadap sodja dadnkjdla dja kdjd ldj");
				GlobalControl.Instance.id = int.Parse( id );
				GlobalControl.Instance.nome = nomeT;
				GlobalControl.Instance.dataPage = result;

				pos = result[result.Length-1].IndexOf(":")+1;

				GlobalControl.Instance.cash = float.Parse( result[result.Length-1].Substring(pos).Trim() );

				StartCoroutine( takeWeapon() );				

				StartCoroutine( wait() );

				foreach ( string a in result ){
					print(a);
				}

			}

		}

	}

	IEnumerator takeWeapon(){
		string query = "select * from weapon where weapon_id in (select id_weapon from user_weapon where id_weapon = "+GlobalControl.Instance.id+")";
		UnityWebRequest link = UnityWebRequest.Get("http://localhost/game/executeQuery.php?query="+query);
		yield return link.SendWebRequest();
		GlobalControl.Instance.userWeapon = link.downloadHandler.text.ToString().Split(';');
				
				foreach(string k in GlobalControl.Instance.userWeapon){
					print(k);
				}

	}

	IEnumerator wait(){

		yield return new WaitForSeconds(2);

		SceneManager.LoadScene("Menu_Scene");

	}


}
