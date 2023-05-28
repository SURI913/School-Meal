using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //주석 깨진거 수정해주세요
    public double Hp; //����ü��
    public double MaxHp; //�ִ�ü��
    public static double enemyHP = 5;

    public static GameManager instance; //싱글턴 접근
    //public double Hp; //현재체력
    //public double MaxHp; //최대체력

    ///public static double enemyHP = 100; //잡몹 체력 플레이어와 동일하다
    public static double MidBossHP = 200; //중간보스 체력 플레이어 보다 큼 임의설정
    public static double BossHP = 500; //중간보스 체력 플레이어 보다 큼 임의설정

    public GameObject enemy;

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

    IEnumerator GameOver(){
        Destroy(BackGroundMusic);
        GameoverSound.Play();
        AllBulrCam.SetActive(true);
        Time.timeScale = 0; //일시정지
        GameOverAnim  = Gameover.GetComponent<Animator>();
        Gameover.SetActive(true);
        GameOverAnim.SetTrigger("isGameOver");
        yield return new WaitForSeconds(1);
        Retry.SetActive(true);
    }

    public void HpSystem()
    {
        if (Hp > MaxHp) //�ִ�ü��
        {
            Hp = MaxHp;
        }
        if (Hp <= 0) // ���
        {
            //죽음 처리하는 함수 만들어서 여기에 생성해주세요

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
    public double GetMidBossHP(){
        return MidBossHP;
    }
    public double GetBossHP(){
        return BossHP;
    }

    //데미지로 인한 체력 조정함수, 공격당할 때 마다 업데이트

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
    public void SetisHitEnemy(bool ishited){    //잡몹
        isEnemyHit = ishited;
    }

    public void SetisHitMidBoss(bool ishited){    //중간보스
        isMidBossHit = ishited;
    }
    public void SetisHitBoss(bool ishited){    //보스
        isBossHit = ishited;
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

    public void enemyHpSystem()
    {
        //적 캐릭터 죽음
        if (enemyHP <= 0)
        {
            Destroy(enemy);
        }
    }

    // 함수 이름 수정 필요
    public void r()
    {
        Hp = Hp + 1;
    }

    public void l()
    {
        Hp = Hp - 1;
    }

    // Update is called once per frame
    void Update()
    {
        HpSystem();
        enemyHpSystem();
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
    public void ChangeStartScene(){;
        SceneManager.LoadScene("StartScene");
    }
    public void ReSetScene(){
        //씬이름변경
        //SceneManager.LoadScene("StartGameScene");
    }

    //플레이 종료 함수
    public void ExitGame(){
        Application.Quit();
    }
    
}
