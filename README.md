VTuber Management Simulator (Console)

C# 콘솔 기반의 VTuber 육성 시뮬레이션 게임입니다.
플레이어는 하나의 VTuber를 생성하고,
방송 · 연습 · 휴식을 반복하며 구독자를 늘리고 이벤트를 관리합니다.

🎮 주요 특징
🔹 VTuber 스탯 시스템

Game / Music / Cute / Mental / Physical

하루 행동에 따라 스탯 변화

피로, 멘탈 등 관리 요소 포함

🔹 자동 스탯 분배 (UX 개선)

생성 시 Space 키로 랜덤 스탯 재분배

마음에 들면 Enter 키로 즉시 시작

최소 스탯 보장 + 총 포인트 제한

🔹 하루 단위 게임 루프

행동 선택 → 결과 반영 → 다음 날 진행

매일 확률적으로 랜덤 이벤트 발생

🔹 랜덤 이벤트 시스템

인터페이스 기반 이벤트 구조

조건 충족 시만 발생

예시 이벤트:

📈 Viral Clip Event (구독자 급증)

😵 Burnout Event (멘탈 감소)

💬 Hatred Comment Event (악플 피해)

🔹 세이브 / 로드 시스템

JSON 기반 저장

다중 세이브 슬롯 지원

슬롯 미리보기 (Day, 저장 시간 표시)

🧩 아키텍처 구조
Managers (초기화 허브)
Managers.Init();


IDataManager : 정적 데이터 로드 (CSV)

IGameManager : 게임 상태 관리

ISceneManager : 씬 전환

ISaveManager : 저장 / 불러오기

IEventManager : 랜덤 이벤트 처리

모든 매니저는 인터페이스 기반으로 분리되어 확장 가능

Scene 시스템

IScene 인터페이스 기반

SceneManager가 씬 생명주기 관리

구현된 씬

TitleScene

CreateScene (VTuber 생성)

MainScene (게임 플레이)

SaveScene

LoadScene

GameManager

하루 진행 및 행동 처리

VTuber 상태 변경

이벤트 트리거 호출

Save / Load 데이터 직렬화 책임

DataManager

CSV 기반 데이터 로드

Dictionary<int, T> 구조 사용

ID 기반 빠른 접근 보장

IReadOnlyDictionary<int, Monster>
IReadOnlyDictionary<int, Item>
IReadOnlyDictionary<int, Job>

💾 저장 구조

JSON 파일

슬롯 단위 저장

Save/
 ├ slot_1.json
 ├ slot_2.json
 └ slot_3.json


버전 필드 포함 (확장 대비)

저장 시간 기록

🛠 기술 스택

Language: C#

Platform: Console (.NET)

Serialization: System.Text.Json

Data: CSV + JSON

Architecture: Interface-based Manager / Scene Pattern

🚀 확장 예정 아이디어

스탯 가중치 분배

VTuber 성향 프리셋

이벤트 로그 / 히스토리

엔딩 분기

UI 개선 (선택 강조, 컬러)

📌 목적

이 프로젝트는
콘솔 환경에서의 게임 아키텍처 설계 연습과
매니저 / 씬 / 데이터 분리 구조를 목표로 합니다.

🔧 Recent Changes – Vtuber Creation Refactor
Vtuber 생성 로직 구조 개선

버튜버 생성 과정에서 Scene가 너무 많은 책임을 가지는 문제를 해결하기 위해
생성 및 스탯 분배 로직을 별도의 Factory로 분리했습니다.

변경 전

CreateScene

이름 입력 처리

스탯 자동 분배 로직

Vtuber 인스턴스 생성

GameManager 생성까지 직접 담당

Scene가 도메인 로직과 UI 로직을 동시에 처리

변경 후

CreateScene

사용자 입력 및 화면 출력만 담당

VtuberFactory

버튜버 생성 규칙 캡슐화

스탯 자동 분배 책임 전담

VtuberCreateData

생성 시 필요한 최소 데이터만 전달하는 DTO 역할

CreateScene
 └─ VtuberFactory.Create(VtuberCreateData)
     └─ AutoDistributeStats()
     └─ Vtuber 생성
