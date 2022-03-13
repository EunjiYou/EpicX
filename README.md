# EpicX

간단한 턴제 게임입니다.
캐릭터마다 임의의 속도를 부여받아 내림차순으로 턴을 잡게됩니다.
적을 먼저 죽이는 것이 승리 조건입니다.

![image](https://user-images.githubusercontent.com/25303946/158066280-8e01cae4-02ea-467a-9373-4a55ef171cc8.png)


# Data Management

유닛 종류는 Hero(탱커, 딜러)와 Enemy가 있습니다.
모든 유닛은 보유한 스탯, 데이터 종류가 같기 때문에 ScriptableObject를 이용해 각 유닛별 속성을 정의 해놓았습니다.
해당 ScriptableObject를 매니저에서 관리하며 유닛 생성 및 유닛 관련 정보를 가져올 때 가져와 사용할 수 있습니다.
(ScriptableObject)

![image](https://user-images.githubusercontent.com/25303946/158066430-aa4f188a-a57f-4a84-a692-ae445a3f303c.png)


(StateMachine에서 BaseStat으로 ScriptableObject를 사용합니다. Stat은 게임 진행 중 변하는 수치이므로 CurStat 이라는 구조체를 추가로 사용하고 있습니다.)

![image](https://user-images.githubusercontent.com/25303946/158066927-f5df6fbf-ceed-4187-8e92-0c3c14d34c5a.png)



# State Machine

유닛은 현재 네 가지 State를 가지고 있고, 해당 State로 변할 경우의 행동이 StateMachine.cs에 정의되어 있습니다.

Idle, ReadyToAttack, Attack, Dead






# Todo

각 유닛 별 특수 스킬 구현

공격이 아닌 버프, 디버프 스킬 구현
