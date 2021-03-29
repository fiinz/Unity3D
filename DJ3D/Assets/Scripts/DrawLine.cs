using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject prefab; // prefab a ser instanciado
    public Transform transformA; // o transform do Ponto a
    public Transform transformB;// o transform do Ponto b
    private Vector3 currentPosition;
    private float m; // declive 
    private float b; //o valor de y quando a reta interseta 

    [SerializeField]
    private float stepX;//step x;
    [Range(1,10)]
    public int numberSteps;
    public int oldSteps;
    [SerializeField]
    private float difX;
    private float difZ;

    [SerializeField]
    private float currentx; // valor currente de x
    private List<GameObject> spheres = new List<GameObject>();
    public float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    { InitializeValues(); }

/* Initialize Values é chamado sempre que é necessário dar reset por isso as instruções foram colocadas fora do start*/
    private void InitializeValues()
    {
        // equações
        // F(x) = y ;
        // y=mx+b;
        // b=y0-m*xo;
        

        // arrendondar valores de forma a obter mais precisão no posicionamento 
        // pode levar a erros de precisão virgula flutuante
        transformA.position = new Vector3(Mathf.Round(transformA.position.x), Mathf.Round(transformA.position.y), Mathf.Round(transformA.position.z));
        transformB.position = new Vector3(Mathf.Round(transformB.position.x), Mathf.Round(transformB.position.y), Mathf.Round(transformB.position.z));
        
        difX = transformB.position.x - transformA.position.x; //deltaX
        difZ = transformB.position.z - transformA.position.z; //deltaY

        m = (difZ / difX); //racio de Z para cada X , isto devolve o declive
        stepX = difX/numberSteps; //direita ou esquerda
        b = transformA.position.z - m * transformA.position.x; // o offset em y quando x=0
        currentx = transformA.position.x; // currentX grava o progresso em X 
        oldSteps = numberSteps; // permite guardar referencia para o valor antigo
        
    }
    void Update()
    {
        if (Time.time < startDelay) return; // dar tempo para carregar a cena 

        // resolução original if(currentx!=transform.position.x)
        // alternativa se pretenderem desenhar tudo de uma vez seria utilizar um ciclo com a quantidade de esferas
        
        if (Mathf.Abs((currentx-stepX)-transformB.position.x)>=0.1f) //cheat -stepX para instanciar mais uma vez 
        {
            currentPosition = new Vector3(currentx, 0, m * currentx + b); 
            var go=Instantiate(prefab);
            spheres.Add(go); // adiciona-se a uma lista para depois poder apagar e voltar a colocar.
            go.transform.position = currentPosition;
            currentx += stepX;
           //colocando b=y-mx e obtem-se o ponto de interseção
        }
        
        // forma de verificar se ocorreu uma alteração no valor de number steps
        if (oldSteps != numberSteps)
        {
            for (int i=spheres.Count-1;i>=0;i--)
            {
                Destroy(spheres[i]);
                spheres.RemoveAt(i);
                InitializeValues();
            }

        }
        //no fim atualizar para guardar o valor atual
        oldSteps = numberSteps;

    }
}
