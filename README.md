# BadKid_GhostBusters
 
## 🎉프로젝트 소개
Visual Studio와 Unity 를 이용해서 C#으로 제작한 프로그램입니다.

## 게임 컨셉
BadKid_GhostBusters : 악동들이 마을을 악령으로 부터 지켜내자
<br>


## 📅개발 기간
* 2024년 2월 8일 ~ 2024년 2월 16일

### 멤버구성
* 김혜림(타칭 갓팀장) - 데이터(승리,패배 조건, 로드 및 저장), 문서정리 , PM
* 박지훈b - UI 
* 신은지 - Monster
* 정현우 - Tower


### 🏟️개발 환경
* Visual Studio 2022
* C#
* .NET 8.0
* Windows
* Nugat 패키지
* Unity

## 주요기능
* 필수기능 - 게임 맵 생성 및 배치, 타워 생성 및 업그레이드, 적의 움직임과 스폰, 타워 공격 로직 , 적과 타워의 체력 및 공격력, 자원관리, 게임 진행 상태 표시, 게임 오버 및 승리조건 

* 선택기능 - 
다양한 타워 유형, 타워 업그레이드 트리, 특수능력 및 스킬, 다양한 적 유형, 사운드 및 그래픽 향상, 레벨 디자인

* Base : 우리 에셋 정말 너무 너무 이뻐요 :)
## CS 구성 
  
### 마을 
* <Invasion_Controller> : 몬스터 충돌시 게임의 오버조건을 관리하기 위한 HP 관리

### 몬스터
* <Monster_Manager> 웨이브 세팅에 따라 몬스터 스폰이나, 몬스터 데이터 초기화를 관리
  
* <Monster_Controller> 각 몬스터의 스테이터스,이동 및 스킬을 관리
  
* <Monster_Status> 몬스터 데이터 변수를 총합해서 관리 (Scriptable Objects화)
  
* <HP_Controller> HP이미지가 항상 카메라 방향으로 회전하도록 관리

### <보스 스킬>
* <Monster_Heal> 몬스터가 전체 HP의 퍼센트로 힐을 하는 기능 관리
  
* <Monster_Change> 포탑의 덱을 체인지 해주는 기능을 관리
  
* <Monster_Bomb> 포탑을 삭제하는 덱을 관리
  
### <기타>
* <TimeScail_Controller> 인게임 타임스케일을 관리

### <타워>
* <Tower_Manager> 타워 전체 데이터 관리, 타워 배치, 리롤 기능
* <Tower_Prototype> 타워 스크립트 전체의 부모 클래스 / 스탯 설정, 공격, 타겟팅, 업그레이드 기능
* <Beam_Tower> 빔 타워의 기능 제어. 같은 적 연속 공격시 공격력 증가 로직
* <Cannon_Tower> 캐논 타워의 기능 제어. 범위 내 무작위 적을 타겟팅하는 로직
* <Density_Enhance_Tower> 밀집 버프 타워의 기능 제어. 인접 십자형 칸에 버프 제공하는 로직
* <Range_Enhance_Tower> 범위 버프 타워의 기능 제어. 인접 사각형 칸에 버프 제공하는 로직
* <Gun_Tower> 건 타워의 기능 제어. 업그레이드 시 총알이 두배로 나가는 로직
* <Sniper_Tower> 스나이퍼 타워의 기능 제어. 맵 전체에서 가장 앞선 적을 타겟팅하는 로직
* <Flame_Tower> 플레임 타워의 기능 제어. 주기적으로 소환물을 소환하는 기능
* <Snow_Tower> 스노우 타워의 기능 제어. 주기적으로 소환물을 소환하는 기능

* <Bullet_Prototype> 총알 스크립트 전체의 부모 클래스 / 타겟과 공격력 받아오기, 이동, 적에게 직접 피해.
* <Gun_Bullet> 건 타워의 총알 기능 제어.
* <Cannon_Bullet> 캐논 타워의 총알 기능 제어. 주변 범위 내의 적 전체에 데미지를 입히는 로직
* <Beam_Bullet> 빔 타워의 총알 기능 제어. 타겟 적에게만 데미지를 입히는 로직
* <Sniper_Bullet> 스나이퍼 타워의 총알 기능 제어. 업그레이드 시 적 잃은 체력 비례 증가 피해를 입히는 로직.

* <Flame_Summon> 플레임 타워의 소환물 기능 제어. 범위 내 적에게 치유 감소와 체력 비례 피해를 입히는 로직.
* <Snow_Summon> 스노우 타워의 소환물 기능 제어. 범위 내 적에게 슬로우 효과를 거는 로직.


-----------------------------------------------------------------------------

## <U.I>
* < AudioVolumeController > 게임의 전체적인 BGM의 볼륨을 조절하는 기능
* < CameraMoveController > 인게임 카메라 줌인,아웃 및 이동 기능
* < EndUIController > 게임이 클리어, 오버 가 되면 나타나는 UI의 기능 제어
* < SideBlurEffectController > 인게임 맵 사이드 검은연기를 제어하는 기능
* < StartUIController > 시작 화면 에서의 UI의 기능 제어
* < GameProgressData > 게임 진행 관련 데이터 관리
* < GoodsData > 인게임 쿠키(재화) 데이터 관리
* < AudioManager > 게임의 전제척인 BGM을 실행
* < Description_Window > 게임 시작 화면에 게임설명 관련 UI 창
* < EndingVideoPlay > 게임 엔딩 씬 플레이
* < FrameSetting > 게임의 프레임을 설정
* < GameUITextAnimation > 게임 UI버튼에 붙어있는 Text를 버튼의 동작과 같이 움직이게 하는 기능

## <데이터>
* <Data> : 게임의 승리 조건, 패배 조건
* <SaveAndLoadManager> : 게임의 데이터 저장 (타워정보,웨이브당 저장) // 현재 해당 부분  부분 구현

### 장르 : 3D 타워 디펜스 

### 스토리 요약 :
유령에게 공격 받는 마을을 지키기 위해 등장한 악동들 !!
악동들의 유령 퇴치 게임 ! 

### 연출 : 
* 타워디펜스와 스킬 이펙트를 이용한 3D 이펙트

### 몬스터 : 
* 일반 몬스터1 : 가장 기본이 되는 몬스터 스폰 확률이 가장 높음
* 일반 몬스터2 : 일반 몬스터 1보다 HP와 공격력이 강화된 몬스터
* 일반 몬스터3 : HP는 작지만 이동속도가 무척 빠른 몬스터

* 특수 몬스터 : 회복 스킬을 사용 할 수 있는 몬스터

* 보스 몬스터1 : 단순하게 체력이 많은 보스 몬스터
* 보스 몬스터2 : 전체 체력 20%의 체력을 회복하는 몬스터 (총 3번)
* 보스 몬스터3 : 3 구역의 타워중 랜덤으로 한 구역의 타워 덱을 전부 바꿔버리는 몬스터(총3번)
* 보스 몬스터4 : 랜덤으로 생성된 타워중 하나를 제거하는 몬스터 (총5번)

### 플레이 방식 :
랜덤배치 되는 타워들을 이용하여 쿠키 (재화)를 가지고 설치하여 유령들을 물리치는 게임

## 자세한  정보는 팀 노션에서 
* https://teamsparta.notion.site/T1-fca79e3e985a48faa7e27de75899d2ad


