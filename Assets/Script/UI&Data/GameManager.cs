using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //싱글턴 접근
    
    double Hp; //현재체력
    double MaxHp; //최대체력
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

    public Slider MusicHandle;
    public GameObject MusicHandleIMG;
    public GameObject SoundHandleIMG;
    public Slider SoundHandle;

    //게임오버
    public GameObject Gameover;
    private Animator GameOverAnim;
    private Animator GameClearAnim;
    public GameObject Retry;
    public GameObject AllBulrCam; //블러처리
    bool isGameOver = false;


    //게임클리어
    bool isClear = false;
    public GameObject Door; //문 오픈
    public GameObject Gameclear;

    //스테이지 관리
    //첫 스타트 스테이지를 1-1로 설정한다 (Start버튼이 눌리고 게임씬이 생성되면 매번 이 씬부터 시작 GameManager 생성을 위해)
    private string StageNumberTag;
    private string BackStageNumberTag;
    public GameObject BackDoor;
    //뒤로가는 문 관리 매점에서는 작동하지 않는다

    public GameObject StageNumber;

    //매점 관리
    public GameObject []Weapon = new GameObject[9]; //무기전체
    private GameObject CurrnetWeaponL;
    private GameObject CurrnetWeaponR;
    private GameObject CurrnetWeaponU;
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

        //플레이어 데이터 가져오기
        Hp = PlayerData.CurrnetHp;
        MaxHp = PlayerData.MaxHp;
        StageNumberTag = PlayerData.CurrentStageTag;
        BackStageNumberTag = PlayerData.BackStageTag;
        BackDoor.tag = BackStageNumberTag;
        Coin = PlayerData.coin;
        isClear = false;
        CurrnetWeaponL = PlayerData.WeaponL;
        CurrnetWeaponR = PlayerData.WeaponR;
        CurrnetWeaponU = PlayerData.WeaponU;
    }

    private void Start(){

        //스테이지 정보 가져오기
        switch (StageNumberTag)
        {
            case "Cafeteria":
                StageNumber.GetComponent<Text>().text = "급식실";
                break;
            case "Office":
                StageNumber.GetComponent<Text>().text = "교장실";
                break;
            case "Shop1":
            case "Shop2":
                StageNumber.GetComponent<Text>().text = "매점";
                break;
            default:
                StageNumber.GetComponent<Text>().text = $"{StageNumberTag[0]}학년 {StageNumberTag[2]}반";
                break;
        }
        AllBulrCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //코인 초기화
        Cointext.GetComponent<Text>().text = $"{Coin}";
        StageState();   //일반맵 클리어 조건 달성했나 체크
    }
    public void gameOver(){
        StopAllCoroutines();
        StartCoroutine(GameOver());
    }

    //게임 오버
    public IEnumerator GameOver()
    {
        if(isGameOver ==false){
            // 게임 오버 처리 로직을 구현하세요
            GameOverAnim = Gameover.GetComponent<Animator>();
            isGameOver = true;
            BackGroundMusic.volume = 0;
            GameoverSound.Play();
            Gameover.SetActive(true);
            GameOverAnim.SetBool("isGameover", true);
            AllBulrCam.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            Retry.SetActive(true);
            Time.timeScale = 0; // 일시정지
            GameOverAnim.SetBool("isGameover", false);
        }
    }
   
    //게임 클리어
    IEnumerator GameClear(){
        GameClearSound.Play();
        GameClearAnim  = Gameclear.GetComponent<Animator>();
        Gameclear.SetActive(true);
        GameClearAnim.SetBool("isGameover", true);   //동일한 애니메이션 사용
        yield return new WaitForSeconds(3.0f);
        GameClearAnim.SetBool("isGameover", false);
        Gameclear.SetActive(false);
        Door.SetActive(true);   //문 오픈
    }

    //게임 클리어 재생
    public void Clear(){
        StartCoroutine(GameClear());
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

    public void setsummonenemyHP(double currentHp)
    {
        summonenemyHP = currentHp;
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
            SoundHandleIMG.GetComponent<Image>().sprite = MuteSound;   //0이면 뮤트이미지로 변경
        }
        else{
            SoundHandleIMG.GetComponent<Image>().sprite = OnSound;   //0이면 뮤트이미지로 변경
        }
        PlayerHitSound.volume = volume;
        EnemyHitSound.volume = volume;
        PlayerAttackSound.volume = volume;
        EnemyAttackSound.volume = volume;
        ButtonSound.volume = volume;
    }

    public void SetMusicVloum(float volume){
        if(volume == 0) {
            MusicHandleIMG.GetComponent<Image>().sprite = MuteMusic;   //0이면 뮤트이미지로 변경
        }
        else{
            MusicHandleIMG.GetComponent<Image>().sprite = OnMusic;   //아니라면 기본이미지
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

    private void ResetData(){
        //모든 값 초기화
        PlayerData.coin = 0;
        PlayerData.CurrnetHp = 100;
        PlayerData.MaxHp = 100;
        //전체 웨폰 배열로 만들어 접근하기
        playerattack.atktype = 0;
        PlayerData.WeaponL = Weapon[0];
        PlayerData.WeaponR = Weapon[1];
        PlayerData.WeaponU = Weapon[2];
        PlayerData.BackStageTag = "1-1";
        PlayerData.CurrentStageTag = "1-1";
        //적 처치 초기화
        PlayerData.BossClear = false;
        PlayerData.MidBossClear = false;
        PlayerData.S1_1Clear = false;
        PlayerData.S1_2Clear = false;
        PlayerData.S1_3Clear = false;
        PlayerData.S2_1Clear = false;
        PlayerData.S2_2Clear = false;
        PlayerData.S2_3Clear = false;
        PlayerData.S3_1Clear = false;
        PlayerData.S3_2Clear = false;
        PlayerData.S4_1Clear = false;
        PlayerData.S4_2Clear = false;
        PlayerData.S4_3Clear = false;
        isClear = false;
        isGameOver = false;
        AllBulrCam.SetActive(false); //블러처리 해제
        BackGroundMusic.volume = 1;

    }

    //씬 전환 함수
    public void ChangeStartScene(){
        Time.timeScale = 1; //일시정지 해제
        ResetData();
        SceneManager.LoadScene("StartScene");
    }

    public void ReSetScene(){
        Time.timeScale = 1; //일시정지 해제
        ResetData();
        SceneManager.LoadScene("1-1");
    }

    //플레이 종료 함수
    public void ExitGame(){
        Time.timeScale = 1; //일시정지 해제
        ResetData();
        Application.Quit();
    }

    public void NonPaused(){
        Time.timeScale = 1; //일시정지 해제
    }

    public void Paused(){
        Time.timeScale = 0; //일시정지
    }

    //매점 구매 함수
    // 가격 무기 5, 전체 체력 채우기 7, 50%채우기 3, 최대체력 올리기 10
    public bool Changeweapon1 =false;
    public bool Changeweapon2 =false;
    public void purchaseWeapon(int number){
        if(number == 2 && Coin >= 5 && CurrnetWeaponL != Weapon[3] && Changeweapon1 ==false){
            //첫번째 상점 무기로 변경
            //속사무기
            playerattack.atktype = 2;
            CurrnetWeaponL =  Weapon[3];
            CurrnetWeaponR = Weapon[4];
            CurrnetWeaponU = Weapon[5];
            Changeweapon1 = true;
            Coin -=5;
            
        }
        else if(number == 1 && Coin >=7 && CurrnetWeaponL != Weapon[6] && Changeweapon2 ==false){
            playerattack.atktype = 1;
            //두번째 상점 무기로 변경
            //관통무기
            CurrnetWeaponL = Weapon[6];
            CurrnetWeaponR = Weapon[7];
            CurrnetWeaponU = Weapon[8];
            Changeweapon2 = true;
            Coin-=7;
        }
        else{
            StartCoroutine(NoCoinState());
        }
    }

    public GameObject NoCoinUI;

    public GameObject GetWeaposnL(){
        return CurrnetWeaponL;
    }
    public GameObject GetWeaposnR(){
        return CurrnetWeaponR;
    }

    public GameObject GetWeaposnU(){
        return CurrnetWeaponR;
    }

    IEnumerator NoCoinState(){
        if(CurrnetWeaponL == Weapon[3]||CurrnetWeaponL == Weapon[6]){
            NoCoinUI.GetComponentInChildren<Text>().text = "소지 중인 무기!";
        }
        else{
            NoCoinUI.GetComponentInChildren<Text>().text = "Coin이 없어요!";
        }
        NoCoinUI.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        NoCoinUI.SetActive(false);
    }

    public void purchaseMaxHpPlus(float plusMaxHp){
        if(Coin >= 7){
            MaxHp+= (double)plusMaxHp;
            Coin -= 7;
        }
        else{
            StartCoroutine(NoCoinState());
        }
    }

    public void purchasehalfHp(){
        if(Coin >= 3){
            Hp += Hp*0.5;
            Coin -= 3;
        }
        else{
            StartCoroutine(NoCoinState());
        }
    }
    public void purchaseMaxHp(){
        if(Coin >= 10){
            Hp = MaxHp;
            Coin -= 10;
        }
        else{
            StartCoroutine(NoCoinState());
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
    private int S1_1 = 4;
    private int S1_2 = 4;
    private int S1_3 = 4;
    private int S2_1 = 1;   //코인 있는 곳 코인먹을때 카운트 올림
    private int S2_2 = 4;
    private int S2_3 = 4;
    private int S3_1 = 5;
    private int S3_2 = 6;
    private int S4_1 = 4;
    private int S4_2 = 1;   //코인 먹을때 카운트 올림
    private int S4_3 = 4;

    private int HitCount = 0;
    
    //보스나 미들보스는 그 개체 죽고 띄우자

    public void HitCountCheck(int i){
        HitCount+=i;
    }

    public void StageState (){
        if(S1_1 == HitCount && isClear == false && StageNumberTag == "1-1"){
            PlayerData.S1_1Clear = true;
            isClear = true;
            Clear();
        }
        if(S1_2 == HitCount && isClear == false && StageNumberTag == "1-2"){
            PlayerData.S1_2Clear = true;
            isClear = true;
            Clear();
        }
        if(S1_3 == HitCount && isClear == false && StageNumberTag == "1-3"){
            PlayerData.S1_3Clear = true;
            isClear = true;
            Clear();
        }
        if(S2_1 == HitCount && isClear == false && StageNumberTag == "2-1"){
            isClear = true;
            PlayerData.S2_1Clear = true;
            Clear();
        }
        if(S2_2 == HitCount && isClear == false && StageNumberTag == "2-2"){
            isClear = true;
            PlayerData.S2_2Clear = true;
            Clear();
        }
        if(S2_3 == HitCount && isClear == false && StageNumberTag == "2-3"){
            isClear = true;
            PlayerData.S2_3Clear = true;
            Clear();
        }
        if(S3_1 == HitCount && isClear == false && StageNumberTag == "3-1"){
            isClear = true;
            PlayerData.S3_1Clear = true;
            Clear();
        }
        if(S3_2 == HitCount && isClear == false && StageNumberTag == "3-2"){
            PlayerData.S3_2Clear = true;
            isClear = true;
            Clear();
        }
        if(S4_1 == HitCount && isClear == false && StageNumberTag == "4-1"){
            PlayerData.S4_1Clear = true;
            isClear = true;
            Clear();
        }
        if(S4_2 == HitCount && isClear == false && StageNumberTag == "4-2"){
            PlayerData.S4_2Clear = true;
            isClear = true;
            Clear();
        }
        if(S4_3 == HitCount && isClear == false && StageNumberTag == "4-3"){
            PlayerData.S4_3Clear = true;
            isClear = true;
            Clear();
        }
    }
    
}
