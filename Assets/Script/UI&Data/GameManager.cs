using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //싱글턴 접근
    
    public double Hp; //현재체력
    public double MaxHp; //최대체력
    public static double enemyHP = 100; //잡몹 체력 플레이어와 동일하다
    public static double MaxenemyHP = 100; //잡몹 체력 플레이어와 동일하다
    public static double summonenemyHP = 30; //중간보스 소환 잡몹 체력 플레이어보다 낮다
    public static double summonMaxenemyHP = 30; //중간보스 소환 잡몹 체력 플레이어보다 낮다
    public static double MidBossHP = 200; //중간보스 체력 플레이어 보다 큼 임의설정
    public static double MaxMidBossHP = 200; //중간보스 체력 플레이어 보다 큼 임의설정
    public static double BossHP = 500; //중간보스 체력 플레이어 보다 큼 임의설정
    public static double MaxBossHP = 500; //중간보스 체력 플레이어 보다 큼 임의설정

    //공격한 적이 누구인가
    private bool isEnemyHit = false;
    private bool isMidBossHit = false;
    private bool isBossHit = false;

    //사운드
    public AudioSource BackGroundMusic; //배경음악
    public AudioSource ButtonSound;//버튼
    public AudioSource PlayerAttackSound;//플레이어 공격
    public AudioSource EnemyAttackSound;//적 공격
    public AudioSource EnemyHitSound;   //적 데미지
    public AudioSource PlayerHitSound;   //플레이어 데미지

    public AudioSource GameoverSound;   //게임오버 사운드
    public AudioSource GameClearSound;   //게임오버 사운드

    //소리가 0일때 스프라이트 변경을 위한 변수
    public Sprite MuteMusic;
    public Sprite OnMusic;
    public Sprite MuteSound;
    public Sprite OnSound;

    public GameObject MusicHandle;
    public GameObject SoundHandle;

    //게임오버
    public GameObject Gameover;
    private Animator GameOverAnim;
    public GameObject Retry;
    public GameObject AllBulrCam; //블러처리

    //게임클리어
    bool isClear = false;
    public GameObject Door; //문 오픈
    public GameObject Gameclear;

    //스테이지 관리
    //첫 스타트 스테이지를 1-1로 설정한다 (Start버튼이 눌리고 게임씬이 생성되면 매번 이 씬부터 시작 GameManager 생성을 위해)
    private int StageNumber1;
    private int StageNumber2;

    public GameObject StageNumber;

    //매점 관리
    public GameObject Weapon1L;
    public GameObject Weapon1R;
    public GameObject Weapon1U;
    public GameObject Weapon2L;
    public GameObject Weapon2R;
    public GameObject Weapon2U;
    public GameObject CurrnetWeaponL;
    public GameObject CurrnetWeaponR;
    public GameObject CurrnetWeaponU;
    private int Coin;
    public GameObject Cointext;


    private void Awake() {
        //싱글턴 변수 instance가 비어있는가?
        if(instance == null){
            //비어있다면 (null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else{
            //instance에 이미 다른 GameManager 오브젝트가 할당되어 있는경우
            Debug.LogWarning("씬에 두 개 이상의 게임매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start(){
        //플레이어 데이터 가져오기
        Hp = PlayerData.CurrnetHp;
        MaxHp = PlayerData.MaxHp;
        StageNumber1 = PlayerData.StageNum1;
        StageNumber2 = PlayerData.StageNum2;
        Coin = PlayerData.coin;
        isClear = false;
        //스테이지 정보 가져오기
        if(StageNumber1 == 0){
            StageNumber.GetComponent<Text>().text = $"급식실";
        }
        else if(StageNumber1 == 9){
            StageNumber.GetComponent<Text>().text = $"교장실";
        }
        else{
            StageNumber.GetComponent<Text>().text = $"{StageNumber1}학년 {StageNumber2}반";
        }

    }

    // Update is called once per frame
    void Update()
    {
        HpSystem(); //플레이어가 죽을 때 모든 동작을 멈추고 GameOver창을 띄운다
        //코인 초기화
        Cointext.GetComponent<Text>().text = $"{Coin}";
    }

    //게임 오버
    IEnumerator GameOver(){
        Destroy(BackGroundMusic);
        GameoverSound.Play();
        AllBulrCam.SetActive(true);
        GameOverAnim  = Gameover.GetComponent<Animator>();
        Gameover.SetActive(true);
        GameOverAnim.SetTrigger("isGameOver");
        Retry.SetActive(true);
        Time.timeScale = 0; //일시정지
        yield return new WaitForSeconds(1);
    }

    //게임 클리어
    IEnumerator GameClear(){
        GameClearSound.Play();
        GameOverAnim  = Gameclear.GetComponent<Animator>();
        Gameclear.SetActive(true);
        GameOverAnim.SetTrigger("isGameOver");  //동일한 애니메이션임
        yield return new WaitForSeconds(2);
        Gameclear.SetActive(false);
        Door.SetActive(true);
    }

    public void HpSystem()
    {
        if (Hp > MaxHp) //체력이 최대체력을 넘어가지 못하게하기
        {
            Hp = MaxHp;
        }
        if (Hp <= 0) // 플레이어 체력이 0이되면 사망
        {
            StartCoroutine(GameOver());
            //리트라이 버튼 누르면 맨 처음 스테이지로 보냄 1학년 1반 스테이지
            //Gameover UI처리
            StartCoroutine("GameOver");
        }
    }


    //HpShlider로 값을 전달할 함수 slider바에서 update로 계속 불러옴 + 공격할 적의 체력 설정을 위한 함수
    public double GetCurrnetHP(){
        return Hp;
    }
    public double GetMaxHP(){
        return MaxHp;
    }
    public double GetenemyHP(){
        return enemyHP;
    }
    public double GetMaxenemyHP(){
        return MaxenemyHP;
    }
    //중간보스소환잡몹 체력
    public double GetsummonenemyHP()
    {
        return summonenemyHP;
    }
    public double GetsummonMaxenemyHP()
    {
        return summonMaxenemyHP;
    }
        
    //중간보스 체력 
    public double GetMaxMidBossHP(){
        return MaxMidBossHP;
    }
    public double GetMidBossHP(){
        return MidBossHP;
    }
    //보스 체력 
    public double GetBossHP(){
        return BossHP;
    }
    public double GetMaxBossHP(){
        return MaxBossHP;
    }

    //데미지로 인한 체력 조정함수, 공격당할 때 마다 업데이트
    public void setMaxHp(double Max){
        MaxHp = Max;
    }

    public void setCurrentHp(double currentHp){
        Hp = currentHp;
    }

    public void setenemyHP(double currentHp){
        enemyHP = currentHp;
    }
    public void setMidBossHP(double currentHp){
        MidBossHP = currentHp;
    }public void setBossHP(double currentHp){
        BossHP = currentHp;
    }

    public bool GetisHitEnemy(){    //잡몹이 공격당했다
        return isEnemyHit;
    }

    public bool GetisHitMidBoss(){    //중간보스가 공격당했다
        return isMidBossHit;
    }
    public bool GetisHitBoss(){    //보스가 공격당했다
        return isBossHit;
    }

    //누가 공격당했는지 설정 , 트리거 실행될때 마다 값 바뀜
    public int setWhoseDamage(int Hit){
        if(Hit == 1){
            isEnemyHit = true;
            isMidBossHit = false;
            isBossHit = false;
        }
        else if(Hit == 2 ){
            isEnemyHit = false;
            isMidBossHit = true;
            isBossHit = false;
        }
        else if(Hit == 3){
            isEnemyHit = false;
            isMidBossHit = false;
            isBossHit = true;
        }
        return 0;
    }

    public int WhoseDamage(){
        //누가 공격받았는가
        if(isEnemyHit){
            return 1;
        }
        else if(isMidBossHit){
            return 2;
        }
        else if(isBossHit){
            return 3;
        }

        return 0;
    }

    
    //효과음 및 배경음악 재생 함수
    public void SetSoundVloum(float volume){
        if(volume == 0) {
            SoundHandle.GetComponent<Image>().sprite = MuteSound;   //0이면 뮤트이미지로 변경
        }
        else{
            SoundHandle.GetComponent<Image>().sprite = OnSound;   //0이면 뮤트이미지로 변경
        }
        PlayerHitSound.volume = volume;
        EnemyHitSound.volume = volume;
        PlayerAttackSound.volume = volume;
        EnemyAttackSound.volume = volume;
        ButtonSound.volume = volume;
    }

    public void SetMusicVloum(float volume){
        if(volume == 0) {
            MusicHandle.GetComponent<Image>().sprite = MuteMusic;   //0이면 뮤트이미지로 변경
        }
        else{
            MusicHandle.GetComponent<Image>().sprite = OnMusic;   //아니라면 기본이미지
        }
        BackGroundMusic.volume = volume;
    }

    public void PlayPlayerHitSound(){   //캐릭터 데미지 입을 때 효과음 함수
        PlayerHitSound.Play();
    }
    public void PlayEnemyHitSound(){    //적 데미지 입을 때 효과음 함수
        EnemyHitSound.Play();
    }
    public void PlayPlayerAttackSound(){    //캐릭터 공격 효과음 함수
        PlayerAttackSound.Play();
    }
    public void PlayEnemyAttackSound(){ //적 공격 효과음 함수
        EnemyAttackSound.Play();
    }

    public void ButtonSoundPlay(){ //UI 버튼 클릭 효과음 함수
        ButtonSound.Play();
    }

    //씬 전환 함수
    public void ChangeStartScene(){
        Time.timeScale = 1; //일시정지 해제
        SceneManager.LoadScene("StartScene");
    }
    public void ReSetScene(){
        Time.timeScale = 1; //일시정지 해제
        //씬이름변경
        SceneManager.LoadScene("1-1");
    }

    //플레이 종료 함수
    public void ExitGame(){
        Time.timeScale = 1; //일시정지 해제
        Application.Quit();
    }

    public void NonPaused(){
        Time.timeScale = 1; //일시정지 해제
    }

    //매점 구매 함수
    // 가격 무기 5, 전체 체력 채우기 7, 50%채우기 3, 최대체력 올리기 10
    public void purchaseWeapon(int number){
        if(number == 1 && Coin >= 5 && CurrnetWeaponL == !Weapon1L){
            //첫번째 상점 무기로 변경
            CurrnetWeaponL = Weapon1L;
            CurrnetWeaponR = Weapon1R;
            CurrnetWeaponU = Weapon1U;
            Coin -=5;
        }
        else if(number == 2 && Coin >=7 && CurrnetWeaponL == !Weapon2L){
            //두번째 상점 무기로 변경
            CurrnetWeaponL = Weapon2L;
            CurrnetWeaponR = Weapon2R;
            CurrnetWeaponU = Weapon2U;
            Coin-=7;
        }
        else{
            
        }
    }

    public GameObject GetWeaposnL(){
        return CurrnetWeaponL;
    }
    public GameObject GetWeaposnR(){
        return CurrnetWeaponR;
    }

    public GameObject GetWeaposnU(){
        return CurrnetWeaponR;
    }

    public void purchaseMaxHpPlus(float plusMaxHp){
        if(Coin >= 7){
            MaxHp+= (double)plusMaxHp;
            Coin -= 7;
        }
    }

    public void purchasehalfHp(){
        if(Coin >= 3){
            Hp += Hp*0.5;
            Coin -= 3;
        }
    }
    public void purchaseMaxHp(){
        if(Coin >= 10){
            Hp = MaxHp;
            Coin -= 10;
        }
    }

    //코인관리 함수
    public int GetCoin(){
        return Coin;
    }
    public void SetCoin(int money){
        Coin += money;
    }

    //스테이지별 클리어 조건

}
