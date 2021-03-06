# Github Action

![.github/workflows/dotnet-core.yml](https://github.com/zkdlu/github-action-example/workflows/.NET%20Core/badge.svg)

- github 저장소를 기반으로 소프트웨어 개발 Workflow를 자동화 할 수 있는 도구. (CI/CD 도구)
- github 저장소에서 발생하는 build, test, package, release, deploy등 다양한 이벤트를 기반으로 직접 원하는 workflow를 만들 수 있다.
- Workflow는 Runners라고 불리는 github에서 호스팅하는 머신의 Linux, macOs, Windows 환경, 컨테이너에서 실행 할 수 있다. 사용자 호스팅 환경에서 직접 구동 가능

> Workflow는 저장소마다 최대 20개까지 등록 가능. 

> Workflow 안에 존재하는 Job이라는 단위마다 최대 6시간동안 실행 될 수 있고, 초과하면 자동으로 중지됨.

> Github 계정 플랜에 따라 전체 Git저장소를 통틀어 동시 실행할 수 있는 Job의 개수가 정해져 있고, Job안에서 Github api를 호출한다면 1시간동안 최대 1000번까지만 가능

> 공개 저장소에는 무료

# Github Action CI
- Github에서 제공하는 CI (지속적 통합) 를 위한 툴
- 각각의 개발자가 개발한 코드를 하나의 저장소에서 통합하는 과정(?)
- 정적분석, 단위 테스트, 분석결과 리포팅, 배포 서버에 push 하는 등의 여러 작업을 수행
- 배포 전에 한 번에 모아서 통합하는 것이 아닌 조금씩 자주 통합해 나가는 과정(?)

### Workflow
- github repository에 대해 일련의 작업들을 수행하는 자동화된 프로세스. 저장소 root에 ./github/workflows/아래에 정의된 .yml 설정 파일 필요

### Event
- workflow가 실행 되도록 만드는 trigger. push, pull request가 있음.

### Job
- 여러개의 step으로 이루어질 수 있으며 단일한 가상 환경을 가짐

### Step
- job안에서 순차적으로 실행되는 프로세스 단위


### 참고
- https://blog.aliencube.org/ko/2019/12/18/building-ci-cd-pipelines-with-github-actions/


## 뇌피셜 (검증 필요)
1. 프로젝트에서 공통으로 사용하는 라이브러리같은 경우 nuget이나 도커 허브, npm 같은 패키지 매니저에서 참조하여 사용함.
2. 그래서 패키지가 변경 되면 빌드하고 패키지 매니저에 업로드를 해야 함. 
3. CI 툴은 이런 행위를 일련의 workflow로 자동화 함.
4. 

## .NET Core에서 사용해보기
### 1. Nuget에 패키지 수동으로 업로드 하기
1. 클래스 라이브러리 프로젝트를 만든 후, .csproj 파일에 패키지 메타데이터 추가
    ```.csproj
    <PropertyGroup>
      <PackageId>DemoLib</PackageId>
      <Version>0.0.1</Version>
      <Authors>zkdlu</Authors>
      <Company>zkdlu</Company>
    </PropertyGroup>
    ```
2. dotnet pack 명령어로 Nuget 패키지(.nupkg)를 빌드
    > 빌드 시 패키지를 자동으로 생성하려면 .csproj안 PropertyGroup 에 GeneratePackageOnBuild태그에 true 를 추가한다.
3. 패키지 게시
    - API 키를 얻기 위해 nuget.org에 로그인하고 새로운 API 키를 만든다.
    - 만들어지면 복사를 선택해 액세스 키를 얻을 수 있음 (나중에 키를 다시 복사할 수 없으므로 안전한 위치에 저장 필요)
    - dotnet nuget push로 게시
        1. .nupkg를 포함하는 디렉토리로 이동한다. (dotnet pack 명령어 결과로 반환 됨)
        2. 명령어 실행
        ```
        dotnet nuget push {.nupkg파일} --api-key {복사한 api키} --source https://api.nuget.org/v3/index.json
        ```
        > 게시가 되기까지 시간이 걸리는데 이메일로 알림이 온다.
        > Nuget.org는 패키지 영구 삭제가 없다고 함.. Listing 수정하는 법 뿐
        
 ### 2. Github Action으로 자동으로 업로드 하기
 - 알아낸 것들
 > - cd 명령어로 이동이 안되서 기본 path에 빌드할 파일이 없으면 path 지정 해줘야 함
 > > - cd 'path' && 이런식으로 되더라. (별개의 태스크라서 그런 듯)
 > - version은 일치 시켜줘야 함
 > - on: push 또는 on [push, pull_request]
 > - setting에 secrets의 값은 ${{ secrets.key }} 로 사용 가능 (api 키값 같은 거에 사용)
```
name: .NET Core
on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2
    - name: Setup .NET Core
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 5.0.100
    - name: Test
      run: ls -al
    - name: Build
      run: dotnet build -c Release -o ./app/Release ./net-core-demo/TestLib
```


- Actions 탭에서 해당 작업 클릭하면 각 step별로 출력 결과 확인 가능

## Java에서 해보기
- maven central repository에 업로드 하여야 함.
- 메이븐의 중앙 저장소에 올리려면 bintray 같은 대행 서비스를 사용하거나 저장소 관리 솔루션인 sonatype에서 제공하는 OSSRH(Open Source Project Repository Hosting)을 사용

 > 꽤 복잡하네;;
 

